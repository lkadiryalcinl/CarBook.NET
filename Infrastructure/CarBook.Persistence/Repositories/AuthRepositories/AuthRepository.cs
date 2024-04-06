using CarBook.Application.Dtos.AuthDtos;
using CarBook.Application.Interfaces.AuthInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook.Persistence.Repositories.AuthRepositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };


            var userRoles = await _userManager.GetRolesAsync(user);

            //claim : jwt içeriğindeki her bir yapı  
            //jwt content
            //        new Claim("FirstName", user.FirstName), string içerisine tanımlamak 
            // için istediğimizi yazabiliriz.
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new("JWTID", Guid.NewGuid().ToString()),
                new("FirstName", user.FirstName),
                new("LastName", user.LastName),

            };

            // "parellel" thread kullanılıyor
            // normal foreachten farkını görebilirsin
            Parallel.ForEach(userRoles, role =>
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            });

            /*
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            */
            var token = GenerateNewJsonWebToken(authClaims);
            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = token
            };
        }

        public async Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var isEmailExist = await _userManager.FindByEmailAsync(registerDto.Email);
            var isNameExist = await _userManager.FindByNameAsync(registerDto.UserName);

            if (isEmailExist != null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Email Zaten Kullanılıyor"
                };

            if (isNameExist != null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Kullanıcı Adı Zaten Kullanılıyor"
                };

            User newUser = new()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            // Security stamp? güvenlik bariyeri
            var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = "User Creation Failed Because: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = errorString
                };
            }
            // Add a Default USER Role to all users
            await _userManager.AddToRoleAsync(newUser, StaticUserRoles.USER);

            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully"
            };
        }

        public async Task<AuthServiceResponseDto> SeedRolesAsync()
        {
            bool isAdminRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.ADMIN);
            bool isAuthorRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.USER);

            if (isAdminRoleExist || isAuthorRoleExist)
                return new AuthServiceResponseDto
                {
                    IsSucceed = true,
                    Message = "Role Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole<int>(StaticUserRoles.USER));
            await _roleManager.CreateAsync(new IdentityRole<int>(StaticUserRoles.ADMIN));
            return new AuthServiceResponseDto
            {
                IsSucceed = true,
                Message = "Role Seeding Done Succesfully"
            };
        }



        private string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenObject = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }

    }
}

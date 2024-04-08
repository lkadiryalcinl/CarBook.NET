using CarBook.Dto.AuthDtos;
using CarBook.WebUI.Models;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBook.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(HttpClientServiceAction httpClientServiceAction, IHttpClientFactory httpClientFactory)
        {
            _httpClientServiceAction = httpClientServiceAction;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<RegisterDto>("Auths/register", registerDto);
            return isSucceded ? RedirectToAction("Login", "Auth") : View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44311/api/Auths/login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<AuthServiceResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new();
                    var token = handler.ReadJwtToken(tokenModel.Message);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Message != null)
                    {
                        claims.Add(new Claim("carbooktoken", tokenModel.Message));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = token.ValidTo,
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

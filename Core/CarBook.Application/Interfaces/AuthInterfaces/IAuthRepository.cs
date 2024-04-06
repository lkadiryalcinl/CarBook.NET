using CarBook.Application.Dtos.AuthDtos;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.AuthInterfaces
{
    public interface IAuthRepository
    {
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto);
    }
}

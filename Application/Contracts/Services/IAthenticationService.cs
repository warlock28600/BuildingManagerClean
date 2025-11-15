using Application.Dto;

namespace Application.Contracts.Services;

public interface IAthenticationService
{
    Task<TokenDto> RegisterAsync(UserRegisterDto userDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
}
using Application.Dto;

namespace Application.Contracts.Repositories;

public interface IAthenticationRepository
{
    Task<TokenDto> RegisterAsync(UserRegisterDto user);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
}
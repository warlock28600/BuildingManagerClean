using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto;


namespace Application.Services;

public class AthenticationService : IAthenticationService
{
    private readonly IAthenticationRepository _repository;

    public AthenticationService(IAthenticationRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<TokenDto> RegisterAsync(UserRegisterDto userDto)
    {
        return await _repository.RegisterAsync(userDto);
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        return await _repository.LoginAsync(loginDto);
    }
}
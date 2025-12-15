
using Application.Contracts.Services;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers;

[Controller]
[Route("api/v1/auth")]
public class AuthenticationController:ControllerBase
{
    private readonly IAthenticationService _service;

    public AuthenticationController(IAthenticationService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<TokenDto> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        return await _service.RegisterAsync(userRegisterDto);
    }

    [HttpPost("login")]
    public async Task<TokenDto> Register([FromBody] LoginDto loginDto)
    {
        return await _service.LoginAsync(loginDto);
    }
    
}
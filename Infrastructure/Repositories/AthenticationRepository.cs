using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Infrastructure.ApplicationDbContext;
using Application.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Application.Contracts.Repositories;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class AthenticationRepository:IAthenticationRepository
{
    #region Constructor
    private readonly ApplicationDbContext.BuildingDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AthenticationRepository> _logger;
    
    public AthenticationRepository( BuildingDbContext context,IMapper mapper,IConfiguration configuration, ILogger<AthenticationRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        _logger = logger;
    }
    #endregion
    
    #region Register Method
    public async Task<TokenDto> RegisterAsync(UserRegisterDto user)
    {
        if (_context.Users.Any(u => u.UserName == user.UserName))
            throw new Exception("Username already exists");
        
        var personEntity=_mapper.Map<Persons>(user);
        _context.Persons.Add(personEntity);
        _context.SaveChanges();
        
        var person= _context.Persons.FirstOrDefault(p => p.FirstName == personEntity.FirstName && p.LastName == personEntity.LastName);
        var userEntity = new Users()
        {
            PersonId = personEntity.Id,
            UserName = user.UserName,
            Password = BCrypt.Net.BCrypt.HashPassword(user.Password),    
        };
        
        _context.Users.AddAsync(userEntity);
        _context.SaveChanges();

        var tokenDto = new TokenDto
        {
            Token =  GenerateJwtToken(userEntity)
        };
        
        return tokenDto;
    }
    #endregion

    #region Login Method
    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _context.Users.Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            throw new Exception("Invalid credentials");
            _logger.LogError("Invalid credentials");
        }
            

        if (user.IsActive == false)
        {
            throw new Exception("User is not active");
            _logger.LogInformation("User is not active");
        }

        var tokenDto = new TokenDto
        {
            Token =GenerateJwtToken(user)
        };
        
        return tokenDto;
    }
    #endregion
    
    #region GenerateJwtToken
    private string GenerateJwtToken(Users user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion
}
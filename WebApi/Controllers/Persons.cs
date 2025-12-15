using Application.Contracts.Services;
using Application.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BuldingManager.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class Persons:ControllerBase
{
    private readonly IPersonService _service;

    public Persons( IPersonService service)
    {
        _service=service;
    }
    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<PersonDto>>  GetPersons()
    {
        return await _service.GetPersons();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<PersonDto> GetPerson(int id)
    {
        return await _service.GetPerson(id);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> PostPerson([FromBody] PersonDto person)
    {
         await _service.CreatePerson(person);
         return Ok();
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerson(int id,[FromBody] PersonDto person)
    {
        await _service.UpdatePerson(id, person);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        await _service.DeletePerson(id);
        return Ok();
    }
    
    
    
    
    
}
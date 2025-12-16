
using Application.Contracts.Services;
using Application.Dto.Unit;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers;

[Controller]
[Route("/api/v1/[controller]")]
public class UnitController:ControllerBase
{

    private readonly IUnitService _unitService;
    
    public UnitController(IUnitService unitService)
    {
        _unitService=unitService;
    }

    [HttpGet]
    public async Task<IEnumerable<UnitGetDto>> GetUnits()
    {
        var units = await _unitService.GetUnitsAsync();
        return units;
    }

    [HttpGet("{id}")]
    public async Task<UnitGetDto> GetUnit(int id)
    {
        var unit= await _unitService.GetUnitAsync(id);
        return unit;
    }

    [HttpPost]
    public Task CreateUnit([FromBody] UnitCreateDto dto)
    {
        return _unitService.CreateUnit(dto);
    }

    [HttpPut("{id}")]
    public Task UpdateUnit(int id, [FromBody] UnitCreateDto dto)
    {
        return _unitService.UpdateUnit(id, dto);
    }

    [HttpDelete("{id}")]
    public Task DeleteUnit(int id)
    {
        return _unitService.DeleteUnit(id);
    }
    
    
}
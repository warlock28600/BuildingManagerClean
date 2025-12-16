
using Application.Contracts.Services;
using Application.Dto.UnitOwner;
using BuldingManager.Services.UnitOwner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UnitOwnerController:ControllerBase
{
    private readonly IUnitOwnerService _unitOwnerService;

    public UnitOwnerController(IUnitOwnerService unitOwnerService)
    {
        _unitOwnerService = unitOwnerService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetUnitOwnerDto>>> GetUnitOwners([FromQuery] string extra)
    {
        var unitOwners = await _unitOwnerService.GetUnitOwners(extra);
        return Ok(unitOwners);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<GetUnitOwnerDto>> GetUnitOwner(int id)
    {
        var unitOwner = await _unitOwnerService.GetUnitOwner(id);
        return Ok(unitOwner);
    }

    [HttpPost]
    [Authorize]
    public Task CreateUnitOwner(CreateUnitOwnerDto unitOwner)
    {
        return _unitOwnerService.CreateUnitOwner(unitOwner);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task UpdateUnitOwner(int id, CreateUnitOwnerDto unitOwner)
    {
        await _unitOwnerService.UpdateUnitOwner(id, unitOwner);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public Task DeleteUnitOwner(int id)
    {
        return _unitOwnerService.DeleteUnitOwner(id);
    }
    
}
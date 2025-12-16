
using Application.Contracts.Services;
using Application.Dto;
using BuldingManager.Services.Building;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BuildingController:ControllerBase
{

    private readonly IBuildingService  _buildingService;
    public BuildingController(IBuildingService buildingService)
    {
            _buildingService= buildingService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetBuildings()
    {
        var buildings = (await _buildingService.GetBuildings()).ToList();
        if (buildings == null || buildings.Count==0)
        {
            return NotFound("No Buildings Found");
        }
        
        return Ok(buildings);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetBuilding(int id)
    {
        var building=await _buildingService.GetBuilding(id);
        if (building == null)
        {
            return NotFound("No Building Found");
        }
        return Ok(building);
    }

    [HttpPost]
    [Authorize]
    public async Task CreateBuilding([FromBody] BuildingCreateDto buildingCreateDto)
    {
        await _buildingService.CreateBuilding(buildingCreateDto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task UpdateBuildings(int id, [FromBody] BuildingCreateDto buildingCreateDto)
    {
        await _buildingService.UpdateBuilding(id, buildingCreateDto);
    }


    [HttpDelete("{id}")]
    [Authorize]
    public async Task DeleteBuilding(int id)
    {
        await _buildingService.DeleteBuilding(id);
    }
    
}
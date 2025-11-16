using Application.Contracts.Repositories;
using Application.Dto;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly IMapper _mapper;
    private readonly BuildingDbContext _context;

    public BuildingRepository(BuildingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Building>> GetBuildingsAsync()
    {
        var buildings = await _context.BuildingEntities.Include(b => b.Units).ToListAsync();
        return buildings;
    }

    public async Task<Building> GetBuildingAsync(int id)
    {
        var building = await _context.BuildingEntities.Include(b => b.Units).FirstOrDefaultAsync(b => b.Id == id);

        if (building == null)
        {
            throw new KeyNotFoundException($"Building with id {id} not found");
        }
        return building;
    }

    public async Task<bool> CreateAsync(Building building)
    {
        _context.BuildingEntities.Add(building);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<bool> UpdateAsync(int id, Building building)
    {
        var buildingEntity = await GetBuildingAsync(id);
        if (buildingEntity == null)
        {
            throw new KeyNotFoundException($"Building with id {id} not found");
        }
        _mapper.Map(building, buildingEntity);
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var buildingEntity = await GetBuildingAsync(id);
        if (buildingEntity == null)
        {
            throw new KeyNotFoundException($"Building with id {id} not found");
        }
        _context.BuildingEntities.Remove(buildingEntity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
}
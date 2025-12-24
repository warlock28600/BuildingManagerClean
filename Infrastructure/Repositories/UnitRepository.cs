using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BuldingManager.Repo.UnitRepo;

public class UnitRepository:IUnitRepository
{
    #region injection
    private readonly BuildingDbContext _context;
    private readonly ILogger<UnitRepository> _logger;
    private readonly IMapper _mapper;

    public UnitRepository(BuildingDbContext context, IMapper mapper, ILogger<UnitRepository> logger)
    {
        _context = context;
        _mapper=mapper;
        _logger = logger;
    }
    #endregion
    
    #region get section
    public async Task<IEnumerable<UnitEntity>> GetAllUnits()
    {

        var units = await _context.UnitEntities.ToArrayAsync();
        if (units.Length == 0)
        {
            throw new Exception("No units found");
            _logger.LogInformation("No units found");
        }
        return units;
    }

    public async Task<UnitEntity> GetUnitById(int id)
    {
        var unit = await _context.UnitEntities.SingleOrDefaultAsync(u => u.UnitId==id);
        if (unit == null)
        {
            throw new Exception("No units found");
            _logger.LogInformation("No units found");
        }
        return unit;
        
    }
    #endregion

    #region create method

    public async Task<bool> CreateUnit(UnitEntity unit)
    {
        _context.UnitEntities.Add(unit);
        var created = await _context.SaveChangesAsync();
        if (created == 0)
        {
            throw new Exception("Unit not created");
            _logger.LogInformation("Unit not created");
        }
        return created>0;
        
    }

    #endregion

    #region update method

    public async Task<bool> UpdateUnit(int id, UnitEntity unit)
    {
        var unitEntity = await GetUnitById(id);
        if (unitEntity == null)
        {
            throw new Exception("No units found");
            _logger.LogInformation("No units found");
        }
        _mapper.Map(unit, unitEntity);
        var updated =await _context.SaveChangesAsync();
        if (updated == 0)
        {
            throw new Exception("Unit not updated");
        }
        return updated>0;
    }

    #endregion

    #region Delete method

    public async Task<bool> DeleteUnit(int id)
    {
        var unitEntity = await GetUnitById(id);
        if (unitEntity == null)
        {
            throw new Exception("No units found");
        }
        _context.UnitEntities.Remove(unitEntity);
        var deleted = await _context.SaveChangesAsync();
        return deleted>0;
    }
    #endregion
}
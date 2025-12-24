using AutoMapper;
using BuldingManager.ApplicationDbContext;
using BuldingManager.Repo.UnitOwner;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;


public class UnitOwnerRepository:IUnitOwnerRepository
{
    #region Constructor
    private readonly BuildingDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UnitOwnerRepository> _logger;

    public UnitOwnerRepository(BuildingDbContext context, IMapper mapper, ILogger<UnitOwnerRepository> logger)
    {
        _context=context;
        _mapper=mapper;
        _logger = logger;
    }
    #endregion

    #region Get Methods
    public async Task<IEnumerable<Domain.Entities.UnitOwner>> GetUnitOwners(string extra)
    {
       var unitOwners = await _context.UnitOwners.Include(u=>u.Unit).Include(u=>u.Unit.Building).Include(u=>u.person).ToListAsync();
       return unitOwners;
    }

    public async Task<Domain.Entities.UnitOwner> GetUnitOwner(int id )
    {
        var unitOwner = await _context.UnitOwners.FindAsync(id);
        return unitOwner;
    }
    #endregion

    #region Create Method
    public Task CreateUnitOwner(Domain.Entities.UnitOwner unitOwner)
    {
        _context.Add(unitOwner);
        return _context.SaveChangesAsync();
    }
    #endregion

    #region Update Method
    public async Task UpdateUnitOwner(int id, Domain.Entities.UnitOwner unitOwner)
    {
        var unitOwnerEntity = await GetUnitOwner(id);
        if (unitOwnerEntity == null)
        {
            throw new Exception("Unit Owner not found");
            _logger.LogError($"Unit Owner not found: {unitOwnerEntity.Unit}");
        }
        _mapper.Map(unitOwner, unitOwnerEntity);
        _context.Entry(unitOwnerEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
    }
    #endregion

    #region Delete Method
    public async Task DeleteUnitOwner(int id)
    {
        
        var unitOwnerEntity = await GetUnitOwner(id);
        if (unitOwnerEntity == null)
        {
            throw new Exception("Unit Owner not found");
            _logger.LogError($"Unit Owner not found: {unitOwnerEntity.Unit}");
        }
         _context.Remove(unitOwnerEntity);
         _context.SaveChangesAsync();
    }
    #endregion
}
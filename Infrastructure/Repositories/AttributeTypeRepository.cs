using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class AttributeTypeRepository : IAttributeTypeRepository
{
    #region Constructor
    private readonly BuildingDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<AttributeTypeRepository> _logger;

    public AttributeTypeRepository(BuildingDbContext context, IMapper mapper, ILogger<AttributeTypeRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    #region Get Methods
    public async Task<IEnumerable<Domain.Entities.AttributeType>> GetAttributeTypes()
    {
        var attributeTypes = await _context.AttributeTypes.ToListAsync();
        return attributeTypes;
    }

    public async Task<Domain.Entities.AttributeType> GetAttributeType(int id)
    {
        var attributeType = await _context.AttributeTypes.SingleOrDefaultAsync(a => a.AttributeTypeId == id);

        if (attributeType == null)
        {
            throw new Exception("Attribute type not found");
        }
        return attributeType;
    }
    #endregion

    #region Create Method
    public async Task<bool> CreateAttributeType(Domain.Entities.AttributeType attributeType)
    {
        _context.AttributeTypes.Add(attributeType);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }
    #endregion

    #region Update Method
    public async Task<bool> UpdateAttributeType(int id, Domain.Entities.AttributeType attributeType)
    {
        var attributeTypeToUpdate = await _context.AttributeTypes.SingleOrDefaultAsync(a => a.AttributeTypeId == id);
        if (attributeTypeToUpdate == null)
            throw new Exception("Attribute type not found");

        // Use AutoMapper to update properties
        _mapper.Map(attributeType, attributeTypeToUpdate);

        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }
    #endregion

    #region Delete Method
    public async Task<bool> DeleteAttributeType(int id)
    {
        var attributeTypeToDelete = await GetAttributeType(id);
        if (attributeTypeToDelete == null)
        {
            throw new Exception("Attribute type not found");
        }
        _context.AttributeTypes.Remove(attributeTypeToDelete);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
    #endregion
}
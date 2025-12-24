
using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        #region Constructor
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AttributeRepository> _logger;

        public AttributeRepository(BuildingDbContext context, IMapper mapper, ILogger<AttributeRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Create Method
        public async Task<bool> CreateAttribute(Domain.Entities.Attribute attribute)
        {
            _context.Attributes.Add(attribute);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        #endregion

        #region Delete Method
        public async Task<bool> DeleteAttribute(int id)
        {
            var attribute = await GetAttributeById(id);
            if (attribute == null)
            {
                throw new Exception("Attribute not found");
                _logger.LogError("Attribute not found");
            }
            _context.Attributes.Remove(attribute);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
        #endregion

        #region Get Method
        public async Task<List<Domain.Entities.Attribute>> GetAllAttributes()
        {
            var attributes = await _context.Attributes.ToListAsync();
            return attributes;
        }

        public async Task<Domain.Entities.Attribute> GetAttributeById(int id)
        {
            var attribute = await _context.Attributes.FirstOrDefaultAsync(a => a.AttributeId == id);
            if (attribute == null)
            {
                throw new Exception("Attribute not found");
            }
            return attribute;
        }
        #endregion

        #region Update Method
        public async Task<bool> UpdateAttribute(int id, Domain.Entities.Attribute attribute)
        {
            var attributeToUpdate = await GetAttributeById(id);
            if (attributeToUpdate == null)
            {
                throw new Exception("Attribute not found");
                _logger.LogError("Attribute not found");
            }
            _mapper.Map(attribute, attributeToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        #endregion
    }
}

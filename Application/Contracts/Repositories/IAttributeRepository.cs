using Domain.Entities;

namespace Application.Contracts.Repositories
{
    public interface IAttributeRepository
    {
        public Task<List<Domain.Entities.Attribute>> GetAllAttributes();
        public Task<Domain.Entities.Attribute> GetAttributeById(int id);
        public Task<bool> CreateAttribute(Domain.Entities.Attribute attribute);
        public Task<bool> UpdateAttribute(int id, Domain.Entities.Attribute attribute);
        public Task<bool> DeleteAttribute(int id);
    }
}

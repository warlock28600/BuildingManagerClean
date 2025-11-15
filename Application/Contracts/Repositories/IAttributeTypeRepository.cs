using Application.Dto.AttributeType;

namespace Application.Contracts.Repositories;

public interface IAttributeTypeRepository
{
    Task<IEnumerable<Domain.Entities.AttributeType>> GetAttributeTypes();
    Task<Domain.Entities.AttributeType> GetAttributeType(int id);
    Task<bool> CreateAttributeType(Domain.Entities.AttributeType attributeType);
    Task<bool> UpdateAttributeType(int id, Domain.Entities.AttributeType attributeType);
    Task<bool> DeleteAttributeType(int id);
}
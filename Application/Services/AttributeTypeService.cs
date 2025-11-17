using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.AttributeType;
using AutoMapper;


namespace BuldingManager.Services.AttributeType;

public class AttributeTypeService : IAttributeTypeService
{

    private readonly IMapper _mapper;
    private readonly IAttributeTypeRepository _repository;

    public AttributeTypeService(IMapper mapper, IAttributeTypeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<AttributeTypeGetDto>> GetAttributeTypes()
    {
        var attributeTypes = await _repository.GetAttributeTypes();
        return _mapper.Map<IEnumerable<AttributeTypeGetDto>>(attributeTypes);
    }

    public async Task<AttributeTypeGetDto> GetAttributeType(int attributeTypeId)
    {
        var attributeType = await _repository.GetAttributeType(attributeTypeId);
        return _mapper.Map<AttributeTypeGetDto>(attributeType);
    }

    public async Task<bool> CreateAttributeType(AttributeTypeCreateAndUpdateDto attributeType)
    {
        return await _repository.CreateAttributeType(_mapper.Map<Domain.Entities.AttributeType>(attributeType));

    }

    public async Task<bool> UpdateAttributeType(int id, AttributeTypeCreateAndUpdateDto attributeType)
    {
        return await _repository.UpdateAttributeType(id, _mapper.Map<Domain.Entities.AttributeType>(attributeType));

    }

    public async Task<bool> DeleteAttributeType(int id)
    {
        return await _repository.DeleteAttributeType(id);

    }
}
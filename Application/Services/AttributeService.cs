using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.Attribute;
using AutoMapper;


namespace Application.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public AttributeService(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAttribute(attributeCreateDto attribute)
        {
           return await _attributeRepository.CreateAttribute(_mapper.Map<Domain.Entities.Attribute>(attribute));
        }

        public async Task<bool> DeleteAttribute(int id)
        {
            return await _attributeRepository.DeleteAttribute(id);
        }

        public async Task<AttributeGetDto> GetAttribute(int attributeId)
        {
            var attribute = await _attributeRepository.GetAttributeById(attributeId);
            return _mapper.Map<AttributeGetDto>(attribute);
        }

        public async Task<IEnumerable<AttributeGetDto>> GetAttributes()
        {
            var attributes = await  _attributeRepository.GetAllAttributes();
            return _mapper.Map<IEnumerable<AttributeGetDto>>(attributes);
        }

        public async Task<bool> UpdateAttribute(int id, attributeCreateDto attribute)
        {
           return await _attributeRepository.UpdateAttribute(id, _mapper.Map<Domain.Entities.Attribute>(attribute));
        }
    }
}

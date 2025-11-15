namespace Application.Contracts.Services
{
    public interface IAttributeService
    {
        Task<IEnumerable<Dto.Attribute.AttributeGetDto>> GetAttributes();
        Task<Dto.Attribute.AttributeGetDto> GetAttribute(int attributeId);
        Task<bool> CreateAttribute(Dto.Attribute.attributeCreateDto attribute);
        Task<bool> UpdateAttribute(int id, Dto.Attribute.attributeCreateDto attribute);
        Task<bool> DeleteAttribute(int id);
    }
}

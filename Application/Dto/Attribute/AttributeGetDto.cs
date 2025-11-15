

using Domain.Entities;

namespace Application.Dto.Attribute
{
    public class AttributeGetDto:BaseEntity
    {
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public string Description { get; set; }
    }
}

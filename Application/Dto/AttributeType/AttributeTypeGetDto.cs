namespace Application.Dto.AttributeType;

public class AttributeTypeGetDto
{
    public int AttributeTypeId { get; set; }
    public string AttributeTypeTitle { get; set; }
    public string Identifier { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}
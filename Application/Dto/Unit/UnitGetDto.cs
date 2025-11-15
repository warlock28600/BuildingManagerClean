using Domain.Entities;

namespace Application.Dto.Unit;

public class UnitGetDto:BaseEntity
{
    public int UnitId { get; set; }
    public string UnitNumber { get; set; }
    public string UnitTitle { get; set; }
    public string Floor { get; set; }
    public int ExtraParkingCount { get; set; }
    public int UnitArea { get; set; }
}
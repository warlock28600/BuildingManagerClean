using Domain.Entities;

namespace Application.Dto.UnitOwner;

public class GetUnitOwnerDto:BaseEntity
{
    public int UnitOwnerId { get; set; }
    public int UnitId { get; set; }
    public int PersonId { get; set; }
    public double? OwnerShipPercent { get; set; }
    public int HouseholdCount { get; set; }
    public int ExtraParkingCount { get; set; }
    public int unitArea { get; set; }
    public Persons person { get; set; }
    public UnitEntity Unit { get; set; }
    
}
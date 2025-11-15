using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities;

public class UnitOwner:BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitOwnerId { get; set; }

    public int UnitId { get; set; }
    public int PersonId { get; set; }
    public double? OwnerShipPercent { get; set; }
    public int HouseholdCount { get; set; }
    public int ExtraParkingCount { get; set; }
    public int unitArea { get; set; }
    
    // navigation property
    public Persons person { get; set; }
    public UnitEntity Unit { get; set; }
}
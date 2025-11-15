using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class UnitEntity:BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitId { get; set; }
    
    public int BuildingId { get; set; }
    public string UnitNumber { get; set; }
    public string UnitTitle { get; set; }
    public string Floor { get; set; }
    public int UnitArea { get; set; }
    public int ExtraParkingCount { get; set; }


    #region Navigation Properties
    public Building Building { get; set; }
    [JsonIgnore]
    public ICollection<UnitOwner> UnitOwners { get; set; }
    [JsonIgnore]
    public ICollection<ResidentEntity> Residents { get; set; }


    public ICollection<UnitExpense> UnitExpenses { get; set; }
    #endregion



}
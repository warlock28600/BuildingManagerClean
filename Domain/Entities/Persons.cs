using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Persons : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public string Mobile { get; set; }

    public Users User { get; set; }

    // navigation property
    [JsonIgnore]
    public ICollection<UnitOwner> UnitOwners { get; set; }
    [JsonIgnore]
    public ICollection<ResidentEntity> Residents { get; set; }
}
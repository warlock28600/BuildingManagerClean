using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string BuildingAddress { get; set; }
        public string BuildingNumber { get; set; }
        public int CompoundId { get; set; }
        [JsonIgnore]
        public ICollection<UnitEntity> Units { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public Compounds Compound { get; set; }
    }
}

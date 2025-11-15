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
    public class AttributeType:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttributeTypeId { get; set; }

        public string AttributeTypeTitle { get; set; }

        public string Identifier { get; set; }

        [JsonIgnore]
        public ICollection<Attribute> Attributes { get; set; }
    }
}

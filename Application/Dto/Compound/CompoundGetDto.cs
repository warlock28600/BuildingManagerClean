
using Domain.Entities;

namespace Application.Dto.Compound
{
    public class CompoundGetDto:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
    }
}

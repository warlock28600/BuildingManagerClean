using Domain.Entities;

namespace Application.Dto.Residents
{
    public class ResidentGetDto:BaseEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public DateTime? MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }
        public string ResidentType { get; set; }
    }
}

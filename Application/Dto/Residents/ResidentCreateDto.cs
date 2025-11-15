namespace Application.Dto.Residents
{
    public class ResidentCreateDto
    {
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public DateTime? MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }
        public string ResidentType { get; set; }
    }
}

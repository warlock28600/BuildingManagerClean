namespace Application.Dto.Unit;

public class UnitCreateDto
{
    public int BuildingId { get; set; }
    public string UnitNumber { get; set; }
    public string UnitTitle { get; set; }
    public string Floor { get; set; }
    public int UnitArea { get; set; }
    public int ExtraParkingCount { get; set; }
}
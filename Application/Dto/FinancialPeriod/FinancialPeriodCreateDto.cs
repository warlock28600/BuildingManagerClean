namespace Application.Dto.FinancialPeriod
{
    public class FinancialPeriodCreateDto
    {    
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

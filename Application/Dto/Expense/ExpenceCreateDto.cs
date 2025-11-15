

using Domain.Statics;

namespace Application.Dto.Expense
{
    public class ExpenceCreateDto
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int FinancialPeriodId { get; set; }
        public int AttributeId { get; set; }

        public ExpanseType ExpanseType { get; set; }
    }
}

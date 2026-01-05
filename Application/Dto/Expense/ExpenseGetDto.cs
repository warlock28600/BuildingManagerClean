
using Domain.Entities;
using Domain.Statics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Expense
{
    public class ExpenseGetDto:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int FinancialPeriodId { get; set; }
        public int BuildingId { get; set; }
        public int AttributeId { get; set; }

        public ExpanseType ExpanseType { get; set; }
    }
}

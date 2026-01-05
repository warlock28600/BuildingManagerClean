using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UnitExpense
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int UnitId { get; set; }
        public decimal Amount { get; set; }

        #region Navigation Properties
        [ForeignKey("ExpenseId")]
        public Expense Expense { get; set; }
        [ForeignKey("UnitId")]
        public UnitEntity Unit { get; set; }
        #endregion
    }
}

namespace Domain.Entities
{
    public class UnitExpense
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int UnitId { get; set; }
        public decimal Amount { get; set; }

        #region Navigation Properties
        public Expense Expense { get; set; }
        public UnitEntity Unit { get; set; }
        #endregion
    }
}

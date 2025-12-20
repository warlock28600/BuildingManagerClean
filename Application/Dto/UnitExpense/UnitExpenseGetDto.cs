namespace Application.Dto.UnitExpense;

public class UnitExpenseGetDto
{
    public int Id { get; set; }
    public int ExpenseId { get; set; }
    public int UnitId { get; set; }
    public decimal Amount { get; set; }
}
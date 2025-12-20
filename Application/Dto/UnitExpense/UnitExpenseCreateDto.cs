namespace Application.Dto.UnitExpense;

public class UnitExpenseCreateDto
{ 
    public int ExpenseId { get; set; }
    public int UnitId { get; set; }
    public decimal Amount { get; set; }
}
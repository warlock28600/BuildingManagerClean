using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class UnitExpenseConfiguration:IEntityTypeConfiguration<UnitExpense>
{
    public void Configure(EntityTypeBuilder<UnitExpense> builder)
    {
            builder.HasOne(x => x.Unit)
            .WithMany(x => x.UnitExpenses)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.Expense)
                .WithMany(x=>x.UnitExpense)
                .HasForeignKey(x => x.ExpenseId)
                .OnDelete(DeleteBehavior.NoAction);
    }
}
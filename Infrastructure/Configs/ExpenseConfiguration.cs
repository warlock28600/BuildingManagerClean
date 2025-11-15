using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(100).IsRequired().HasColumnType("varchar(100)");
            builder.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.Description).HasMaxLength(500).HasColumnType("varchar(500)");
            builder.Property(e => e.ExpanseType).IsRequired().HasColumnType("int");
            builder.HasOne(e => e.Attribute)
                   .WithMany(a => a.Expenses)
                   .HasForeignKey(e => e.CostTypeId)
                   .OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(e => e.FinancialPeriod)
                   .WithMany(fp => fp.Expenses)
                   .HasForeignKey(e => e.FinancialPeriodId)
                   .OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}

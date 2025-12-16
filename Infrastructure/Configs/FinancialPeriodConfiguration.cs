using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class FinancialPeriodConfiguration : IEntityTypeConfiguration<FinancialPeriod>
    {
        public void Configure(EntityTypeBuilder<FinancialPeriod> builder)
        {
            builder.Property(fp => fp.Title).HasMaxLength(50).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(fp => fp.StartDate).IsRequired().HasColumnType("datetime");
            builder.Property(fp => fp.EndDate).IsRequired().HasColumnType("datetime");
            
        }
    }
}

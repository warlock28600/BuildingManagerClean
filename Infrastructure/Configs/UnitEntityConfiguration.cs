using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuldingManager.Configs;

public class UnitEntityConfiguration:IEntityTypeConfiguration<UnitEntity>
{
    public void Configure(EntityTypeBuilder<UnitEntity> builder)
    {
        builder.Property(u => u.Floor).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u=>u.UnitTitle).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u=>u.UnitNumber).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
    }
}
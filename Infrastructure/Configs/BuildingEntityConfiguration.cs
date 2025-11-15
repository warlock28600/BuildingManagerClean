using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuldingManager.Configs;

public class BuildingEntityConfiguration:IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.Property(b=>b.Title).HasMaxLength(24).IsRequired().HasColumnType("varchar(24)");
        builder.Property(b=>b.BuildingAddress).HasMaxLength(256).IsRequired().HasColumnType("varchar(256)");
        builder.Property(b=>b.BuildingNumber).IsRequired().HasColumnType("varchar(10)");
        builder.HasOne(b=>b.Compound).WithMany(c=>c.Buildings).HasForeignKey(b=>b.CompoundId).OnDelete(DeleteBehavior.Cascade);
    }
}
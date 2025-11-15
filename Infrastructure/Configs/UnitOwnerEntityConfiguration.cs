using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class UnitOwnerEntityConfiguration:IEntityTypeConfiguration<UnitOwner>
{
    public void Configure(EntityTypeBuilder<UnitOwner> builder)
    {
        
        builder.HasOne(uo => uo.Unit)
            .WithMany(u => u.UnitOwners)
            .HasForeignKey(uo => uo.UnitId);

        builder.HasOne(uo => uo.person)
            .WithMany(p => p.UnitOwners)
            .HasForeignKey(uo => uo.PersonId);
    }
}
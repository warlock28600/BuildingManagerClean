using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuldingManager.Configs
{
    public class ResidentEntityConfiguration : IEntityTypeConfiguration<ResidentEntity>
    {
        public void Configure(EntityTypeBuilder<ResidentEntity> builder)
        {
            builder.Property(e => e.ResidentType).HasMaxLength(50).IsRequired();
            builder.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Unit).WithMany().HasForeignKey(e => e.UnitId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(e => new { e.PersonId, e.UnitId }).IsUnique();
            builder.Property(e=>e.MoveInDate).IsRequired();
            builder.Property(e=>e.PersonId).IsRequired();
            builder.Property(e=>e.UnitId).IsRequired();
        }
    }
}

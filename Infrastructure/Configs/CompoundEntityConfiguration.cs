using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configs
{
    public class CompoundEntityConfiguration : IEntityTypeConfiguration<Compounds>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Compounds> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired();
            builder.HasMany(c => c.Buildings)
                .WithOne(b => b.Compound)
                .HasForeignKey(b => b.CompoundId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

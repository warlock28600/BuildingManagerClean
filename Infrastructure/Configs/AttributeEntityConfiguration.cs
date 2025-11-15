using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class AttributeEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Attribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.Property(a => a.AttributeTypeId).IsRequired();
            builder.Property(a=>a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a=>a.Description).HasMaxLength(500);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class AttributeTypeEntitiesConfiguration : IEntityTypeConfiguration<AttributeType>
    {
        public void Configure(EntityTypeBuilder<AttributeType> builder)
        {
            builder.Property(a=>a.AttributeTypeTitle).HasMaxLength(150).IsRequired();
            builder.Property(a=>a.Identifier).HasMaxLength(50).IsRequired();
            
        }
    }
}

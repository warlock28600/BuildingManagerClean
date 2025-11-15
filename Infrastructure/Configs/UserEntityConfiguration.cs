using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class UserEntityConfiguration:IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(20);
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Role).HasDefaultValue("User");
    }
}
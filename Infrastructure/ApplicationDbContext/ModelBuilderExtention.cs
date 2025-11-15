
using BuldingManager.Configs;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace BuldingManager.ApplicationDbContext;

public static class ModelBuilderExtention
{
    public static void ApplyAllEntityConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BuildingEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UnitEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UnitOwnerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AttributeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AttributeTypeEntitiesConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new FinancialPeriodConfiguration());
        modelBuilder.ApplyConfiguration(new CompoundEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ResidentEntityConfiguration());
    }
}
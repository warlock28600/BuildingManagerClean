using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ApplicationDbContext;

public partial class BuildingDbContext : DbContext
{
    public DbSet<Persons> Persons { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Building> BuildingEntities { get; set; }
    public DbSet<UnitEntity> UnitEntities { get; set; }
    public DbSet<UnitOwner> UnitOwners { get; set; }    
    public DbSet<AttributeType> AttributeTypes { get; set; }
    public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
    public DbSet<Domain.Entities.ResidentEntity> Residents{ get; set; }
    public DbSet<Domain.Entities.Compounds> Compounds { get; set; }
    public DbSet<Domain.Entities.FinancialPeriod> FinancialPeriods { get; set; }
    public DbSet<Domain.Entities.Expense> Expenses { get; set; }
    public DbSet<UnitExpense> UnitExpenses { get; set; }
}
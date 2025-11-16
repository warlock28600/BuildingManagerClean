using Application.Contracts.Repositories;
using BuldingManager.Repo.UnitOwner;
using BuldingManager.Repo.UnitRepo;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public static class RepositoryCollectionExtensions
{

    public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
    {


        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IAthenticationRepository, AthenticationRepository>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IUnitOwnerRepository, UnitOwnerRepository>();
        services.AddScoped<IAttributeTypeRepository, AttributeTypeRepository>();
        services.AddScoped<IAttributeRepository, AttributeRepository>();
        services.AddScoped<IResidentRepository, ResidentRepository>();
        services.AddScoped<ICompoundRepository, CompoundRepository>();
        services.AddScoped<IFinancialPeriodRepository, FinancialPeriodRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        return services;
    }
    
}
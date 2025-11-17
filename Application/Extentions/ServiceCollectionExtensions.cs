// Extensions/ServiceCollectionExtensions.cs

using System.Reflection;
using Application.Contracts.Services;
using Application.Services;
using AutoMapper;
using BuldingManager.Services.AttributeType;
using BuldingManager.Services.Building;
using BuldingManager.Services.Expense;
using BuldingManager.Services.FinancialPeriod;
using BuldingManager.Services.UnitOwner;
using Microsoft.Extensions.DependencyInjection;

namespace BuldingManager.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAthenticationService, AthenticationService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUnitOwnerService, UnitOwnerService>();
            services.AddScoped<IAttributeTypeService, AttributeTypeService>();
            services.AddScoped<IAttributeService, AttributeService>();
            services.AddScoped<IResidentService, ResidentService>();
            services.AddScoped<ICompoundService, CompoundService>();
            services.AddScoped<IFinancialPeriodService, FinancialPeriodService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            // هر سرویس دیگه‌ای که خواستی...
            // services.AddScoped<IMyService, MyService>();

            return services;
        }
    }
}
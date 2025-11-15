using BuldingManager.ApplicationDbContext;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DepedencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuildingDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddJwtAuthentication(configuration);
            services.AddSwaggerWithJwt(configuration);
            return services;
        }
    }
}

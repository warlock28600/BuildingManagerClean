using BuldingManager.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class BuildingDbContextFactory : IDesignTimeDbContextFactory<BuildingDbContext>
{
    public BuildingDbContext CreateDbContext(string[] args)
    {
        var apiPath = Path.GetFullPath(Path.Combine(
         Directory.GetCurrentDirectory(),
         "..",       // فقط یک بار بالا برو
         "WebAPI"    // نام پروژه API
     ));

        Console.WriteLine("API Path: " + apiPath); // برای تست

        var config = new ConfigurationBuilder()
            .SetBasePath(apiPath)
            .AddJsonFile("appsettings.json")
            .Build();

        Console.WriteLine("File exists: " + File.Exists(Path.Combine(apiPath, "appsettings.json")));

        var optionsBuilder = new DbContextOptionsBuilder<BuildingDbContext>();
        var connectionString = config.GetConnectionString("SqlServerConnection");

        Console.WriteLine("connection: " + connectionString);

        optionsBuilder.UseSqlServer(connectionString);

        return new BuildingDbContext(optionsBuilder.Options);
    }
}

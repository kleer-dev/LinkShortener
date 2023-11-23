using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LinkShortener.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var connectionString = GetConnectionString();
        
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new ApplicationContext(optionsBuilder.Options);
    }
    
    private string GetConnectionString()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!
            .Replace("LinkShortener.Data", "LinkShortener.Presentation");
        var builder = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json");
        
        var configuration = builder.Build();

        var connectionString = configuration["Db:ConnectionString"];
        
        if (connectionString is null)
            throw new NullReferenceException("The connections string is missing");

        return connectionString;
    }
}
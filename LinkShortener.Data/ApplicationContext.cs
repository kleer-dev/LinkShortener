using LinkShortener.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Url> Urls { get; set; } = null!;

    public ApplicationContext()
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user id=root;database=link.shortener";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            builder =>
            {
                builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        
        base.OnConfiguring(optionsBuilder);
    }
}
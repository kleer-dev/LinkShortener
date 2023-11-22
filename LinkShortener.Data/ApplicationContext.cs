using LinkShortener.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Url> Urls { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
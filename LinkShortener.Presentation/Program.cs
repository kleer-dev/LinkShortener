using LinkShortener.Application.Interfaces;
using LinkShortener.Application.Services;
using LinkShortener.Data;
using LinkShortener.Data.Entities;
using LinkShortener.Data.Interfaces;
using LinkShortener.Data.Repositories;
using LinkShortener.Presentation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration["Db:ConnectionString"];
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), 
        contextOptionsBuilder => 
            contextOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IRepository<Url>, UrlRepository>();
builder.Services.AddScoped<ILinkShorterService, LinkShorterService>();
builder.Services.AddScoped<IUrlService, UrlService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.MapControllerRoute(
    name: "default",
    pattern: "{shortLink}",
    defaults: new { controller = "Home", action = "ShortLink" });

app.Run();
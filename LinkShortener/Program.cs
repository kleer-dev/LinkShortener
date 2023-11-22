using LinkShortener.Data;
using LinkShortener.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UrlRepository>();
builder.Services.AddScoped<ApplicationContext>();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseMySQL(builder.Configuration["Db:ConnectionString"] ?? string.Empty, 
        opt =>
    {
        opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

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

app.Run();
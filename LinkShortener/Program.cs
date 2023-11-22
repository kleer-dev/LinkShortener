using LinkShortener.Data;
using LinkShortener.Data.Repositories;
using LinkShortener.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<UrlRepository>();
builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<LinkShorterService>();

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

app.UseEndpoints(routes =>
{
    routes.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    
    routes.MapControllerRoute(
        name: "default",
        pattern: "{shortLink}",
        defaults: new { controller = "Home", action = "Index" });

});

app.Run();
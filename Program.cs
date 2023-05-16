using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEvidence.Data;
using MvcEvidence.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcOsobaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcOsobaContext") ?? throw new InvalidOperationException("Connection string 'MvcOsobaContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


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
    pattern: "{controller=Osoby}/{action=Index}/{id?}");

app.Run();

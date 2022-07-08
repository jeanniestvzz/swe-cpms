using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using CPMS.Data;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


/*var configuration = new ConfigurationBuilder()
      .SetBasePath(Path.Combine(AppContext.BaseDirectory))
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .Build();
var connstring = configuration.GetConnectionString("DefaultConnection");*/
builder.Services.AddDbContext<CPMSContext>(options => options.UseSqlServer("Server=JEANNIE-ESTEVEZ; Database=CPMS; User ID=ADMIN; Password=cpmsadmin; trusted_connection=yes;"));
//DbContextOptionsBuilder optionsBuilder;
//optionsBuilder.UseSqlServer("Server=JEANNIE-ESTEVEZ; Database=CPMS; User ID=ADMIN; Password=cpmsadmin; trusted_connection=yes;");

builder.Services.AddDbContext<CPMSContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

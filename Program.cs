using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using StudyingProcedures.Controllers;
using StudyingProcedures.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CitiesContext>(options =>
    options.UseSqlServer("Server=DESKTOP-IHC10EU\\SQLEXPRESS;Database=citiesDatabase;Integrated Security=true;TrustServerCertificate=True")
);
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeController}/{action=Index}/{id?}");

app.Run();


using StudyingProcedures.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeController}/{action=Index}/{id?}");

app.Run();


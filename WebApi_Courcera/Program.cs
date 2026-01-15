using WebApi_Courcera.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CustomAuthenticationMiddleware>();
app.MapControllers();

app.Run();

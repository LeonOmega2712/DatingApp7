using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add the DB contexto to our services list
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite( // This method comes from the EntityFrameworkCore.Sqlite NuGet
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

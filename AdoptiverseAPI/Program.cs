using AdoptiverseAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AdoptiverseApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AdoptiverseApiDb") ?? throw new InvalidOperationException("Connection string 'AdoptiverseApiDb' not found.")).UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

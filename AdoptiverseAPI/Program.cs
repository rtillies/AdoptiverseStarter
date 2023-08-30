using AdoptiverseAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Updating this line will get you past the initial 'object cycle' error!
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

builder.Services.AddDbContext<AdoptiverseApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AdoptiverseApiDb") ?? throw new InvalidOperationException("Connection string 'AdoptiverseApiDb' not found.")).UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

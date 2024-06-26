using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using roboApi.Core.Services;
using roboApi.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RoboDbContext>();
builder.Services.AddScoped<CotoveloService>();
builder.Services.AddScoped<PulsoService>();
builder.Services.AddScoped<CabecaService>();
builder.Services.AddScoped<RoboService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(configure =>
    {
        configure
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

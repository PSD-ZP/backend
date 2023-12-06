using ClothesHandler.Calculator;
using PlaygroundWeatherState.DryCalculator;
using PlaygroundWeatherState.WetnessScoreCalculator;
using ServicePDV.Services;
using ServicePDV.Services.impl;
using ServicePVD.Services;
using ServicePVD.Services.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;
})
.AddNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddSingleton<IWetnessScore, WetnessScore>();
builder.Services.AddSingleton<IDryingTimeCalculator, DryingTimeCalculator>();
builder.Services.AddSingleton<IRecommendationCalculator, RecommendationCalculator>();
builder.Services.AddScoped<IClothesService, ClothesService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IPlaygroundService, PlaygroundService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
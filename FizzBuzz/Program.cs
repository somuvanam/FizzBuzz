using FizzBuzz.Factories;
using FizzBuzz.Services;
using FizzBuzz.Services.Rules;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IFizzBuzzService, FizzBuzzService>();
// Register the services
builder.Services.AddTransient<IFizzBuzzRule, FizzBuzzRule>();
builder.Services.AddTransient<IFizzBuzzRule, FizzRule>();
builder.Services.AddTransient<IFizzBuzzRule, BuzzRule>();

// Register the factory
builder.Services.AddTransient<IFizzBuzzRuleFactory, FizzBuzzRuleFactory>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

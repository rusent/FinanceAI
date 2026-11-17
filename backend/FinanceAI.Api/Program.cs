using FinanceAI.Business.Interfaces;
using FinanceAI.Business.Services;
using FinanceAI.DataAccess.Contexts;
using FinanceAI.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("FinanceAIDatabase");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Connection string 'FinanceAIDatabase' was not found or is empty.");
}

builder.Services.AddDbContext<FinanceAIDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<
    ITransactionService, TransactionService>();

builder.Services.AddScoped<
    ITransactionRepository, TransactionRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "FinanceAI API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

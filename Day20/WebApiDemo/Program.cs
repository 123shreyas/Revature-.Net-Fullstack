using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Load appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Controllers
builder.Services.AddControllers();

// Register DataAccessLayer services
builder.Services.AddDataAccessLayer();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerProfile));

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerDTOValidator>();

// Database
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CrmDbConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("CrmDbConnection"))
    ));

var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();
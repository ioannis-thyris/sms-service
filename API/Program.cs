using API.Filters;
using API.Middleware;
using API.ServiceConfiguration;
using DataAccessLayer;
using Database.AppContext;
using Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add filters

builder.Services.ConfigureFilters();

//Add database
var connectionString = builder.Configuration.GetConnectionString("SmsService");

builder.Services.ConfigureDatabase(connectionString);


builder.Services.AddAutoMapper(typeof(SmsProfile));

//Add repositories
builder.Services.ConfigureDataAccessLayer();

// Vendors
builder.Services.ConfigureVendors();

//Add validation services
builder.Services.ConfigureValidations();

//Add cors
builder.Services.ConfigureCors();



var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<VendorMiddleware>();

app.MapControllers();

app.Run();

using API.Filters;
using API.Middleware;
using DataAccessLayer;
using Database.AppContext;
using Domain.DataTransferObjects;
using Domain.Mapping;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SmsVendors.Contracts;
using SmsVendors.Vendors;
using SmsVendors.Vendors.CY;
using SmsVendors.Factory;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add filters
builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddScoped<VendorFilter>();

//Add database
var catalogName = builder.Configuration.GetConnectionString("SmsService");


builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(catalogName)
);

builder.Services.AddAutoMapper(typeof(SmsProfile));

//Add repositories
builder.Services.AddScoped<ISmsRepository, SmsRepository>();

// Add vendors
builder.Services.AddScoped<ISmsVendorGR, SmsVendorGR>();
builder.Services.AddScoped<ISmsVendorCY, SmsVendorCY>();
builder.Services.AddScoped<ISmsVendorRest, SmsVendorRest>();

// Add factory
builder.Services.AddScoped<ISmsVendorFactory>(provider => new SmsVendorFactory(provider));

// Add selector
builder.Services.AddSingleton<ISmsVendorSelector, VendorSelector>();

builder.Services.AddScoped<ValidationFilter>();

//Add validation services
//builder.Services.AddValidatorsFromAssemblyContaining<SmsValidatorCY>();

builder.Services.AddScoped<ISmsValidatorGR, SmsValidatorGR>();
builder.Services.AddScoped<ISmsValidatorCY, SmsValidatorCY>();
builder.Services.AddScoped<ISmsValidatorRest, SmsValidatorRest>();

//Add cors

builder.Services.AddCors(c =>
{
    c.AddPolicy("allowAll", options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});


var app = builder.Build();



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

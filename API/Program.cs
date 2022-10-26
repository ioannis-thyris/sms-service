using API.Filters;
using API.Middleware;
using DataAccessLayer;
using Database.AppContext;
using Domain.DataTransferObjects;
using Domain.Mapping;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SmsVendors.Core;
using SmsVendors.Vendors;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add filters
builder.Services.AddScoped<ValidationFilter>();

//Add database
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer("")
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




//Add validation services
builder.Services.AddValidatorsFromAssemblyContaining<SmsValidatorCY>();

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

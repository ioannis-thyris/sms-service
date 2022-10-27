using API.Filters;
using DataAccessLayer;
using Database.AppContext;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmsVendors.Contracts;
using SmsVendors.Factory;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;
using System;

namespace API.ServiceConfiguration
{
    internal static class Configuration
    {
        public static void ConfigureDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<ISmsRepository, SmsRepository>();

        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilter>();
            services.AddScoped<VendorFilter>();
        }

        public static void ConfigureValidations(this IServiceCollection services)
        {
            services.AddScoped<ISmsValidatorGR, SmsValidatorGR>();
            services.AddScoped<ISmsValidatorCY, SmsValidatorCY>();
            services.AddScoped<ISmsValidatorRest, SmsValidatorRest>();

        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("allowAll", options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });
        }

        public static void ConfigureDatabase(this IServiceCollection services, string catalogName)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(catalogName)
            );
        }

        public static void ConfigureVendors(this IServiceCollection services)
        {
            services.AddScoped<ISmsVendorGR, SmsVendorGR>();
            services.AddScoped<ISmsVendorCY, SmsVendorCY>();
            services.AddScoped<ISmsVendorRest, SmsVendorRest>();
            services.AddScoped<ISmsVendorFactory>(provider => new SmsVendorFactory(provider));
        }

    }
}

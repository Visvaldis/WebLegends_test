using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebLegends_test.BLL.Interfaces;
using WebLegends_test.BLL.Services;
using WebLegends_test.DAL;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Interfaces;
using WebLegends_test.DAL.Repositories;

namespace WebLegends_test.BLL.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)            
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EfContext>(options =>
                  options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IFacilityLogService, FacilityLogService>();
            services.AddScoped<IFacilityStatusService, FacilityStatusService>();
        }
    }
}

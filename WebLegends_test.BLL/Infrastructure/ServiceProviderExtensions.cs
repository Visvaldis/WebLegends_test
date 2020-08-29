using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Interfaces;
using WebLegends_test.DAL.Repositories;

namespace WebLegends_test.BLL.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddUnitOfWorkService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EfContext>(options =>
                  options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

﻿using Dashboard.Application.Common.Interfaces;
using Dashboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DB Context
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));

            //todo: checked if this works
            services.AddScoped<IAppDbContext, AppDbContext>();
            //services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            //services.AddIdentityServer();

            return services;
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Buglogger.Application
{
    public static class DependecyInjection
    {
       public static IServiceCollection AddApplication(this IServiceCollection services)
       {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
       }
    }
}

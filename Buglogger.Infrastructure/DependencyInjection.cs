﻿using Buglogger.Application.Interfaces;
using Buglogger.Infrastructure.Identity;
using Buglogger.Infrastructure.Persistence.Data;
using Buglogger.Infrastructure.Services;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;

namespace Buglogger.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AppDbContext>();

            if (environment.IsEnvironment("Test"))
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, AppDbContext>(options =>
                    {
                        options.Clients.Add(new Client
                        {
                            ClientId = "Buglogger.IntegrationTests",
                            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedScopes = { "Buglogger.Api", "openid", "profile" }
                        });
                    }).AddTestUsers(new List<TestUser>
                    {
                        new TestUser
                        {
                            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                            Username = "shubham@buglogger.in",
                            Password = "Buglogger1!",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "shubham@buglogger.in")
                            }
                        }
                    });
            }
            else
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, AppDbContext>();

                services.AddTransient<IIdentityService, IdentityService>();
                services.AddTransient<IDateTime, DateTimeService>();
            }

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddIdentityServerJwt();

            return services;
        }
    }
}
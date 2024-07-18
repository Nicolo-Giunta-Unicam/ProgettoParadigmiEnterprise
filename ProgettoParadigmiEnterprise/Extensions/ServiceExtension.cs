using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Repositories;
using ProgettoParadigmiEnterprise.Services;
using FluentValidation;
using ProgettoParadigmiEnterprise.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProgettoParadigmiEnterprise.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseRistorante>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("Paradigmi"));
            });
            services.AddScoped<OrdineRepository>();
            services.AddScoped<PortataRepository>();
            services.AddScoped<UtenteRepository>();
            services.AddScoped<JwtTokenService>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "ProgettoParadigmiEnterprise"));
            services.AddScoped<IOrdineService, OrdineService>();
            services.AddScoped<IPortataService, PortataService>();
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            return services;
        }

        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = new JwtAuthenticationOption();
            configuration.GetSection("JwtAuthentication").Bind(jwt);

            services.Configure<JwtAuthenticationOption>(configuration.GetSection("JwtAuthentication"));
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                string key = jwt.Key;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt.Issuer,
                    IssuerSigningKey = securityKey
                };
            });

            return services;
        }
    }
}

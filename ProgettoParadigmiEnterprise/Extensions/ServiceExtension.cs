using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Repositories;
using ProgettoParadigmiEnterprise.Services;
using FluentValidation;

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
            return services;
        }
    }
}

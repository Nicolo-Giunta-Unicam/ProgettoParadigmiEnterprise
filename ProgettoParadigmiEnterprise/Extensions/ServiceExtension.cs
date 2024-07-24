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
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

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
            // Per far si che gli enum siano visualizzati tramite la loro etichetta e non il valore intero
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            return services;
        }

        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ProgettoParadigmiEnterprise",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            services.AddFluentValidationAutoValidation();

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

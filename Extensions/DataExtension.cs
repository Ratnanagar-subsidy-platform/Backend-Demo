using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetWares.Configurations;
using NetWares.Data;
using NetWares.Exceptions;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Models;
using NetWares.Repository;
using NetWares.Service;

namespace NetWares.Extensions
{
    public static class DataExtension
    {

        public static void AddDependencyInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddJwtAuthentication(configuration);
            services.AddCorsConfiguration();
            services.AddExceptionHandler<GlobalExceptionHandling>();
            services.AddRepository();
            services.AddServices();
            services.AddControllers();
            services.Configure<JwtOption>(configuration.GetSection("JwtConfig"));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }



        private static void AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var postgresConnString = configuration.GetConnectionString("PostgresConnection");
            Console.WriteLine(postgresConnString);
            services.AddDbContextFactory<AppDbContext>(options =>
            {
                options.UseNpgsql(postgresConnString, npgsqlOptions =>
                        npgsqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(60),
                            errorCodesToAdd: null
                        )
                )
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(); // Enable sensitive data logging here
            });
        }

        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISubsidyRepository, SubsidyRepository>();
            services.AddScoped<ISubsidyEntryRepository, SubsidyEntryRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITrainingParticipantRepository, TrainingParticipantRepository>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubsidyService, SubsidyService>();
            services.AddScoped<ISubsidyEntryService, SubsidyEntryService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingParticipantService, TrainingParticipantService>();
        }
        private static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddPolicy("AllowAny", builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
            return services;
        }
        private static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("JwtConfig").Get<JwtOption>()
                ?? throw new NullReferenceException("JwtConfig is null");
            var secret = config.SecretKey;
            if (string.IsNullOrEmpty(secret))
            {
                throw new InvalidOperationException("JWT secret is missing in configuration");
            }

            var key = Encoding.ASCII.GetBytes(secret);
            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config.Issuer,
                ValidAudience = config.Audience
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
                jwt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException)
                        {
                            throw new SecurityTokenExpiredException("The token has expired.");
                        }

                        throw new UnauthorizedAccessException(context.Exception.Message);
                    },
                    OnChallenge = context =>
                    {
                        if (!context.Response.HasStarted)
                        {
                            throw new UnauthorizedAccessException("You are not authorized.");
                        }

                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        throw new UnauthorizedAccessException("You do not have permission to access this resource.");
                    }
                };

            });

            services.AddSingleton(tokenValidationParameters);
        }
    }
}
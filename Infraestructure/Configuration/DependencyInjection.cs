using System.Security.Cryptography;
using System.Text;
using Application.Interfaces;
using Application.Interfaces.Identity;
using Domain.User.Queries;
using Domain.User.Repositories;
using Infraestructure.AppDbContext;
using Infraestructure.Options.Identity;
using Infraestructure.Queries.User;
using Infraestructure.Repositories.User;
using Infraestructure.Services.Identity;
using Infraestructure.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Scrutor;

namespace Infraestructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext(configuration)
            .AddRepositories()
            .AddQueries()
            .AddServices(configuration)
            .AddJwtBearerConfiguration(configuration);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conncetion = configuration.GetConnectionString("dbConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(conncetion, builder =>
            {
                builder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: null
                )
                .CommandTimeout(180);
            }),
            ServiceLifetime.Transient
        );

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(selector => selector.FromAssemblies(
                     typeof(IUsersRepository).Assembly,
                     typeof(UsersRepository).Assembly)
                 .AddClasses(
                    filter => filter.Where(x => x.Name.EndsWith("Repository")),
                    publicOnly: false
                 )
                 .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                 .AsMatchingInterface()
                 .WithTransientLifetime());

        return services;
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(selector => selector.FromAssemblies(
             typeof(IUsersQueries).Assembly,
             typeof(UsersQueries).Assembly)
         .AddClasses(
              filter => filter.Where(x => x.Name.EndsWith("Queries")),
              publicOnly: false
          )
         .UsingRegistrationStrategy(RegistrationStrategy.Skip)
         .AsMatchingInterface()
         .WithScopedLifetime());

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        configuration.GetSection("Identity").Get<IdentityOptions>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
        services.AddTransient<IUserAuthService, UserAuthService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        return services;
    }

    private static IServiceCollection AddJwtBearerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        configuration.GetSection("Identity").Get<IdentityOptions>();

        var key = Encoding.UTF8.GetBytes(IdentityOptions.ClientSecret);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = new TimeSpan(0, 0, 30)
            };
        });

        services.AddTransient<IUserAuthService, UserAuthService>();

        return services;
    }
}
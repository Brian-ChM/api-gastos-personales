using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Configuration.DependencyInjection.Mediator;
using Application.Configuration.Automapper;

namespace Application.Configuration.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCustomAutomapper()
            .AddCustomeMediatR();

        return services;
    }
}

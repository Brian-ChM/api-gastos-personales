using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration.DependencyInjection.Mediator;

internal static class MediatorConfiguration
{
    public static IServiceCollection AddCustomeMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}

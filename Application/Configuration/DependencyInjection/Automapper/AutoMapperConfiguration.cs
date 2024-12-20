using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Configuration.Automapper;

internal static class AutoMapperConfiguration
{
    public static IServiceCollection AddCustomAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}

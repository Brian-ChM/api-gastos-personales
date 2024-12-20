using System.Reflection;

namespace WebApi.Configuration.Automapper;

internal static class AutoMapperConfiguration
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(new Assembly[]
        {
            Assembly.GetExecutingAssembly(),
        });
        return services;
    }
}

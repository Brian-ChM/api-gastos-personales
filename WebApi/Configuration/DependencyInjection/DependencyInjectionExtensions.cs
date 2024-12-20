using Infraestructure.Configuration;
using Application.Configuration.DependencyInjection;
using WebApi.Configuration.Automapper;
using WebApi.Configuration.Swagger;

namespace WebApi.Configuration.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        services
            .ConfigureAutoMapper()
            .ConfigureCustomSwagger()
            .AddInfraestructure(configuration)
            .AddApplication(configuration);

        return services;
    }
}

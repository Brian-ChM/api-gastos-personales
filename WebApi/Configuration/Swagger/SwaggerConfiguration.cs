using Microsoft.OpenApi.Models;

namespace WebApi.Configuration.Swagger;

internal static class SwaggerConfiguration
{
    public static IServiceCollection ConfigureCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.DescribeAllParametersInCamelCase();
            c.CustomSchemaIds(t => t.Name);

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter [space] and then your token in the text input below.",
                Name = "Authorization",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme,
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }
}

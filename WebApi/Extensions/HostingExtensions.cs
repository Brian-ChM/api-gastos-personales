using WebApi.Configuration.DependencyInjection;
using WebApi.Middleware;

namespace WebApi.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, IWebHostEnvironment env)
    {
        builder.Services.AddApi(builder.Configuration, env);

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseMiddleware<CustomExceptionMiddleware>();
        app.MapControllers();
        app.UseHttpsRedirection();

        app.UseCors("SpecificOrigin");
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseStatusCodePages();
        return app;
    }
}

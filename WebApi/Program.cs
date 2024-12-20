using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices(builder.Environment)
    .ConfigurePipeline(builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

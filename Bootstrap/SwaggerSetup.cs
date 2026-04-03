using System.Reflection;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(cfg =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            cfg.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}
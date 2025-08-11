namespace TodoApp.Startup;

public static class OpenApiSetup
{
    public static void AddOpenApiSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Version = "v1",
                Title = builder.Environment.ApplicationName,
                Description = "A simple ASP.NET Core Todo app Web API",
            });
        });
    }

    public static void ConfigureWebApiForDevelopment(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
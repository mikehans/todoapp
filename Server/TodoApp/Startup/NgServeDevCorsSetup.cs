namespace TodoApp.Startup;

public static class NgServeDevCorsSetup
{
    static string _myAllowDevNgServeOrigin = "_allowDevNgServeOrigin";

    public static void AddNgServeDevCorsServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: _myAllowDevNgServeOrigin,
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
        });
    }

    public static void UseNgServeDevCorsServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors(_myAllowDevNgServeOrigin);
        }
    }
}
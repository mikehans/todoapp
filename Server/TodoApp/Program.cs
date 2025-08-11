using TodoApp.Routes;
using TodoApp.Startup;
using Todos.Service;
using Todos.Service.Contracts;
using Todos.Service.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddSingleton<IDataAccess, FakeDataAccess>();

builder.AddOpenApiSetup();

builder.AddNgServeDevCorsServices();

var app = builder.Build();

app.ConfigureWebApiForDevelopment();

app.UseNgServeDevCorsServices();

app.UseHttpsRedirection();

app.AddTodoRoutes();

app.Run();
using TodoApp.Routes;
using TodoApp.Startup;
using Todos.Service;
using Todos.Service.Contracts;
using Todos.Service.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddSingleton<IDataAccess, FakeDataAccess>();

builder.AddOpenApiSetup();

var app = builder.Build();

app.ConfigureWebApiForDevelopment();

app.UseHttpsRedirection();

app.AddTodoRoutes();

app.Run();
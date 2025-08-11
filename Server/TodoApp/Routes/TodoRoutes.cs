using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Todos.Service.Contracts;
using Todos.Service.Models;

namespace TodoApp.Routes;

public static class TodoRoutes
{
    private static IConfiguration _config;

    public static void AddTodoRoutes(this WebApplication app)
    {
       _config = app.Configuration;

       app.MapGet("/todos", GetAll);
       app.MapGet("/todos/{id:int}",GetById);
       app.MapPut("/todos/{id:int}", ToggleComplete);
       app.MapPost("/todos", AddTodo);
    }

    public async static Task<IResult> GetAll(ITodoService svc)
    {
        List<Todo> todos = await svc.GetAll();

        return Results.Ok(todos);
    }

    public async static Task<IResult> GetById(int id, ITodoService svc)
    {
        Todo todo = await svc.GetById(id);

        if (todo.Id == -1)
        {
            return Results.NotFound();
        }
        else
        {
            return Results.Ok(todo);
        }
    }

    public async static Task<IResult> ToggleComplete(int id, ITodoService svc, HttpRequest req)
    {
        var completed = await svc.ToggleComplete(id);
        if (completed.Id == -1)
        {
            return Results.NotFound();
        }
        else
        {
            var addr = req.Scheme + "://" + req.Host.Value + req.Path.Value;
            return Results.Ok(addr);
        }
    }

    public async static Task<IResult> AddTodo(Todo newTodo, ITodoService svc, HttpRequest req)
    {
        var id = await svc.AddTodo(newTodo);
        var addr = req.Scheme + "://" + req.Host.Value + req.Path.Value + "/" + id;
         
        return Results.Created(addr, newTodo);
    }
}
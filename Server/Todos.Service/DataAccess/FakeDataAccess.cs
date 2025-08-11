using Todos.Service.Contracts;
using Todos.Service.Models;

namespace Todos.Service.DataAccess;

public class FakeDataAccess : IDataAccess
{
    private List<Todo> _todos;

    public FakeDataAccess()
    {
        _todos = new List<Todo>
        {
            new Todo()
            {
                Id = 1,
                Title = "Todo 1",
                Description = "Description 1",
            },
            new Todo()
            {
                Id = 2,
                Title = "Todo 2",
                Description = "Description 2",
            }
        };
    }

    public Task<Todo> AddTodo(Todo newTodo)
    {
        var nextId = _todos.Max(t => t.Id) + 1;
        newTodo.Id = nextId;
        _todos.Add(newTodo);

        return Task.FromResult(newTodo);
    }

    public Task<List<Todo>> GetAll()
    {
        return Task.FromResult(_todos);
    }

    public Task<Todo> GetOne(int id)
    {
        var firstResult = _todos.FirstOrDefault(t => t.Id == id);
        var result = firstResult ?? new Todo() { Id = -1, Title = "" };

        return Task.FromResult(result);
    }

    public Task<Todo> ToggleComplete(int id)
    {
        var foundTodo = _todos.Find(t => t.Id == id);
        if (foundTodo != null)
        {
            foundTodo.IsComplete = !foundTodo.IsComplete;
            return Task.FromResult(foundTodo);
        }
        else
        {
            return Task.FromResult(new Todo(){Id=-1, Title = ""});
        }
    }
}
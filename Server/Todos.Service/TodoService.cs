using Todos.Service.Contracts;
using Todos.Service.Models;

namespace Todos.Service;

public class TodoService : ITodoService
{
    private readonly IDataAccess _dataAccess;

    public TodoService(IDataAccess da)
    {
        _dataAccess = da;
    }

    public async Task<List<Todo>> GetAll()
    {
        return await _dataAccess.GetAll();
    }

    public async Task<Todo> GetById(int id)
    {
        return await _dataAccess.GetOne(id);
    }

    public async Task<bool> ToggleComplete(int id)
    {
        var item = await _dataAccess.ToggleComplete(id);

        return item;
    }

    public async Task<int> AddTodo(Todo todo)
    {
        var id = await _dataAccess.AddTodo(todo);
        return id;
    }
}
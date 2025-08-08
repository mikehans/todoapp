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

    public async Task<List<Todo>> MarkSelectionsComplete(List<Todo> todos)
    {
        return await _dataAccess.MarkComplete(todos);
    }

    public async Task<Todo> MarkOneComplete(Todo todo)
    {
        var returneditems = await _dataAccess.MarkComplete(new List<Todo> { todo });
        return returneditems.FirstOrDefault();
    }
}
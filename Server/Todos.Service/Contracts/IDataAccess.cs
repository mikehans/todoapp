using Todos.Service.Models;

namespace Todos.Service.Contracts;

public interface IDataAccess
{
    Task<Todo> AddTodo(Todo newTodo);
    Task<List<Todo>> GetAll();
    Task<Todo> GetOne(int id);
    Task<Todo> ToggleComplete(int id);
}
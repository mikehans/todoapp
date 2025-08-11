using Todos.Service.Models;

namespace Todos.Service.Contracts;

public interface ITodoService
{
    Task<List<Todo>> GetAll();
    Task<Todo> GetById(int id);
    Task<bool> ToggleComplete(int id);
    Task<int> AddTodo(Todo todo);
}
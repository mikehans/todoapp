using Todos.Service.Models;

namespace Todos.Service.Contracts;

public interface ITodoService
{
    Task<List<Todo>> GetAll();
    Task<Todo> GetById(int id);
    Task<Todo> ToggleComplete(int id);
    Task<Todo> AddTodo(Todo todo);
}
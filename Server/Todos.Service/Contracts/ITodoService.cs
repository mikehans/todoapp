using Todos.Service.Models;

namespace Todos.Service.Contracts;

public interface ITodoService
{
    Task<List<Todo>> GetAll();
    Task<Todo> GetById(int id);
    Task<List<Todo>> MarkSelectionsComplete(List<Todo> todos);
    Task<Todo> MarkOneComplete(Todo todo);
}
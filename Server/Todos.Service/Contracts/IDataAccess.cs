using Todos.Service.Models;

namespace Todos.Service.Contracts;

public interface IDataAccess
{
    Task<int> AddTodo(Todo newTodo);
    Task<List<Todo>> GetAll();
    Task<Todo> GetOne(int id);
    Task<List<Todo>> MarkComplete(List<Todo> todosToMarkComplete);
}
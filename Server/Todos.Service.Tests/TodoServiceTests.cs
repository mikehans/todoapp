using Todos.Service.DataAccess;
using Todos.Service.Models;

namespace Todos.Service.Tests;

public class TodoServiceTests
{
    private TodoService sut;

    [SetUp]
    public void Setup()
    {
        var sutData = new FakeDataAccess();
        sut = new TodoService(sutData);
    }

    [Test]
    public void GetAll_ShouldReturnListOfActiveTodos()
    {
        var todos = Task.WhenAll(sut.GetAll()).Result;

        Assert.That(todos, Has.Length.GreaterThanOrEqualTo(1));
    }

    [Test]
    public void GetById_ShouldReturnOneTodoSelectedById()
    {
        var todo = Task.WhenAll(sut.GetById(1)).Result.First();

        Assert.That(todo, Has.Property("Title").EqualTo("Todo 1"));
    }

    [Test]
    public void MarkOneComplete_ShouldReturnOneCompletedTodo()
    {
        var todoToBeCompleted = new Todo() { Id = 2, Title = "" };
        var completedTodo = Task.WhenAll(sut.MarkOneComplete(todoToBeCompleted)).Result.First();

        Assert.That(completedTodo, Has.Property("IsComplete").True);
        Assert.That(completedTodo, Has.Property("CompletedDateTime").Not.Null);
    }
}
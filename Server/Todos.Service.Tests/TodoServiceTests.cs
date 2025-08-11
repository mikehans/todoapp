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
    public void GetById_ShouldReturnOneTodo()
    {
        var todo = Task.WhenAll(sut.GetById(1)).Result.First();

        Assert.That(todo, Has.Property("Title").EqualTo("Todo 1"));
    }

    [Test]
    public void GetById_ShouldReturnTodoWithDefaultIdWhenIdNotInDataSource()
    {
        var todo = Task.WhenAll(sut.GetById(111111111)).Result.First();

        Assert.That(todo, Has.Property("Id").EqualTo(-1));
    }

}
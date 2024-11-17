using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace ToDo_list.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public void_ AddTodo_ShouldAddTodo()
        {
            var todoService = new TodoService();

            var todo = todoService.AddTodo("Test title", "Test description");

            Assert.NotNull(todo);
            Assert.Equal(0, todo.ids);
            Assert.Equal("Test title", todo.titles);
            Assert.Equal("Test description", todo.descriptions);
            Assert.Single(todoService.GetAllTodos());
        }

        [Fact]
        public void_ GetAllTodos_ShouldReturnAllTodos()
        {
            var todoService = new TodoService();
            todoService.AddTodo("title 1", "description 1");
            todoService.AddTodo("title 2", "description 2");

            var todos = todoService.GetAllTodos();

            Assert.Equal(2, todos.Count);
            Assert.Contains(todos, t => t.titles == "title 1" && t.descriptions == "description 1");
            Assert.Contains(todos, t => t.titles == "title 2" && t.descriptions == "description 2");
        }

        [Fact]
        public void_ DeleteTodo_ShouldDeleteTodo()
        {
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test title", "Test description");

            var result = todoService.DeleteTodo(todo.ids);

            Assert.True(result);
            Assert.Empty(todoService.GetAllTodos());
        }

        [Fact]
        public void_ UpdateTodo_ShouldUpdateTodo()
        {
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test title", "Test description");

            var result = todoService.UpdateTodo(todo.ids, "Updated title", "Updated description");

            Assert.True(result);
            var updatedTodo = todoService.GetAllTodos().First();
            Assert.Equal("Updated title", updatedTodo.titles);
            Assert.Equal("Updated description", updatedTodo.descriptions);
        }
        [Fact]
        public void_ SaveTodo_title_IsEmpty_ReturnsErrorMessage()
        {
            var todoService = new TodoService();
            string title_ = "";
            string description_ = "Test description";

            var result = todoService.SaveTodo(titles, descriptions);

            Assert.Equal("Пустой заголовок. Повторите попыткку", result);
        }

        [Fact]
        public void_ SaveTodo_Valid_title_Anddescription__ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title_ = "Test title";
            string description_ = "Test description";

            var result = todoService.SaveTodo(titles, descriptions);

            Assert.Equal("Успешно добавлено", result);
            
        }
        [Fact]
        public void_ SaveTodo_Valid_title_Anddescription_IsEmpty_ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title_ = "Test title";
            string description_ = "";

            var result = todoService.SaveTodo(titles, descriptions);

            Assert.Equal("Успешно добавлено", result);

        }
        [Fact]
        public void_ SaveTodo_title_IsEmptyAnddescription_IsEmpty_ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title_ = "";
            string description_ = "";

            var result = todoService.SaveTodo(title_, description_);

            Assert.Equal("Пустой заголовок. Повторите попытку", result);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_list
{
    public class TodoService
    {
        private ObservableCollection<Todo> _todos = new ObservableCollection<Todo>();
        
        private int _nextId = 0;

        public Todo AddTodo(string title, string description)
        {
            var todo = new Todo { ids = _nextId++, titles = title, descriptions = description };
            _todos.Add(todo);
            return todo;
        }


        public List<Todo> GetAllTodos()
        {
            return _todos.ToList();
        }

        public bool DeleteTodo(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.ids == id);
            if (todo == null) return false;

            _todos.Remove(todo);
            return true;
        }

        public bool UpdateTodo(int id, string title, string description)
        {
            var todo = _todos.FirstOrDefault(t => t.ids == id);
            if (todo == null) return false;

            todo.titles = title;
            todo.descriptions = description;
            return true;
        }
        public string SaveTodo(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return "Пустой заголовок. Повторите попытку";
            }

            try
            {
                AddTodo(title, description);
                return "Добавлено";
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }

}

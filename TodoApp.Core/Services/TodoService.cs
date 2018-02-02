using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Services
{
    public class TodoService : ITodoService
    {
        public Task CompleteTodoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateTodoAsync(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return Task.FromResult(new List<TodoItem> {
                new TodoItem { Id = 1, Content = "First item" },
                new TodoItem { Id = 2, Content = "Second item" },
                new TodoItem { Id = 3, Content = "Third item" },
            }.AsEnumerable());
        }
    }
}

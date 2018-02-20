using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Todo;

namespace TodoApp.Core.Services
{
    public class TodoService : ITodoService
    {
        protected ITodoStorageService TodoStorage { get; }

        public TodoService(ITodoStorageService todoStorage)
        {
            TodoStorage = todoStorage;
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return TodoStorage.GetAllAsync();
        }

        public async Task CreateAsync(string content)
        {
            await TodoStorage.CreateAsync(content);
        }

        public Task CheckAsync(int todoId)
        {
            return TodoStorage.CheckAsync(todoId);
        }

        public Task UncheckAsync(int todoId)
        {
            return TodoStorage.UncheckAsync(todoId);
        }
    }
}

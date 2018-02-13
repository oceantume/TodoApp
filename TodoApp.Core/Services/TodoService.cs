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
        protected ITodoStorage Storage { get; }

        public TodoService(ITodoStorage todoStorage)
        {
            Storage = todoStorage;
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return Storage.GetAllAsync();
        }

        public async Task CreateAsync(string content)
        {
            int id = await Storage.CreateAsync(content, false);
        }
        
        public Task FinishAsync(int id)
        {
            var update = new TodoStorageUpdate(id)
                .SetDone(true);

            return Storage.UpdateAsync(update);
        }

        public Task UnfinishAsync(int id)
        {
            var update = new TodoStorageUpdate(id)
                .SetDone(false);

            return Storage.UpdateAsync(update);
        }
    }
}

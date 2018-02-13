using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Core.Todo;

namespace TodoApp.Core.Storage
{
    /// <summary>
    /// Simple in-memory storage for todo items. Uses a simple semaphore to ensure thread safety.
    /// </summary>
    public class InMemoryTodoStorage : ITodoStorage
    {
        private List<TodoItem> _items = new List<TodoItem>();
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            await _semaphore.WaitAsync();

            try
            {
                return _items.Select(i => new TodoItem(i.Id, i.Content, i.Done));
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<int> CreateAsync(string content, bool done)
        {
            await _semaphore.WaitAsync();
            
            try
            {
                var id = (_items.Max(i => i.Id as int?) ?? 0) + 1;

                _items.Add(new TodoItem(id, content, done));

                return id;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        
        public async Task UpdateAsync(TodoStorageUpdate update)
        {
            await _semaphore.WaitAsync();

            try
            {
                var index = _items.FindIndex(i => i.Id == update.Id);
                var item = _items[index];

                var content = update.Content.GetValueOr(item.Content);
                var done = update.Done.GetValueOr(item.Done);

                _items[index] = new TodoItem(update.Id, content, done);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}

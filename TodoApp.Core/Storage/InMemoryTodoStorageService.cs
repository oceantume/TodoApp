using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Core.Extensions;
using TodoApp.Core.Todo;

namespace TodoApp.Core.Storage
{
    public class InMemoryTodoStorageService : ITodoStorageService
    {
        private int _lastId = 0;
        private List<TodoItem> _items = new List<TodoItem>();
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            using (await _semaphore.WaitAsyncAndGuard())
            {
                return _items.Select(i => new TodoItem(i.Id, i.Content, i.Checked));
            }
        }

        public async Task<int> CreateAsync(string content)
        {
            using (await _semaphore.WaitAsyncAndGuard())
            { 
                var id = ++_lastId;

                _items.Add(new TodoItem(id, content, false));

                return id;
            }
        }

        public async Task CheckAsync(int todoId)
        {
            using (await _semaphore.WaitAsyncAndGuard())
            {
                SetChecked(todoId, true);
            }
        }

        public async Task UncheckAsync(int todoId)
        {
            using (await _semaphore.WaitAsyncAndGuard())
            {
                SetChecked(todoId, false);
            }
        }


        private void SetChecked(int todoId, bool newChecked)
        {
            var index = FindItemIndex(todoId);
            _items[index] = new TodoItem(todoId, _items[index].Content, newChecked);
        }

        private int FindItemIndex(int todoId)
        {
            var index = _items.FindIndex(i => i.Id == todoId);

            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(todoId), todoId, "no item found with this id");

            return index;
        }
    }
}

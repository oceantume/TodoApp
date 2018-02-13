using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public interface ITodoStorage
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<int> CreateAsync(string content, bool done);
        Task UpdateAsync(TodoStorageUpdate update);
    }
}

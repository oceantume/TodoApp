using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task CompleteTodoAsync(int id);
        Task CreateTodoAsync(TodoItem item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();

        Task CreateAsync(string content);

        Task SetCheckedAsync(int todoId, bool newValue);
    }
}

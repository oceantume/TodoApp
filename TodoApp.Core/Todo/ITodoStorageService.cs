using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public interface ITodoStorageService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<int> CreateAsync(string content);
        Task CheckAsync(int todoId);
        Task UncheckAsync(int todoId);
    }
}

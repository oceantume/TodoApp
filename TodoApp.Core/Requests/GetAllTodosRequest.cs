using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Todo;

namespace TodoApp.Core.Requests
{
    public class GetAllTodosRequest : IRequest<IEnumerable<TodoItem>>
    {
    }
}

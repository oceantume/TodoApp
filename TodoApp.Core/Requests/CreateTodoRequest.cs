using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Requests
{
    public class CreateTodoRequest : IRequest<int>
    {
        public string Content { get; set; }
    }
}

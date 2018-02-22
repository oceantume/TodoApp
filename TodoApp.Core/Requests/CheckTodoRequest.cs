using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Requests
{
    public class CheckTodoRequest : IRequest
    {
        public int TodoId { get; set; }
        public bool Checked { get; set; } = true; 
    }
}

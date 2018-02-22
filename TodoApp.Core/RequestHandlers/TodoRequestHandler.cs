using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Core.Requests;
using TodoApp.Core.Todo;

namespace TodoApp.Core.RequestHandlers
{
    public class TodoRequestHandler : 
        IRequestHandler<GetAllTodosRequest, IEnumerable<TodoItem>>,
        IRequestHandler<CreateTodoRequest, int>,
        IRequestHandler<CheckTodoRequest>
    {
        private ITodoStorageService TodoStorageService { get; }

        public TodoRequestHandler(ITodoStorageService todoStorageService)
        {
            TodoStorageService = todoStorageService;
        }

        public Task<int> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
            return TodoStorageService.CreateAsync(request.Content);
        }

        public Task<IEnumerable<TodoItem>> Handle(GetAllTodosRequest request, CancellationToken cancellationToken)
        {
            return TodoStorageService.GetAllAsync();
        }

        public Task Handle(CheckTodoRequest message, CancellationToken cancellationToken)
        {
            if (message.Checked)
                return TodoStorageService.CheckAsync(message.TodoId);
            else
                return TodoStorageService.UncheckAsync(message.TodoId);
        }
    }
}

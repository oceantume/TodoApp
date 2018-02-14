using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TodoApp.Core;
using TodoApp.Core.Todo;
using TodoApp.Web.ActionFilters;
using TodoApp.Web.ViewModels;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private ITodoService TodoService { get; }

        public TodoController(ITodoService todoService)
        {
            TodoService = todoService;
        }

        public async Task<ActionResult> Index()
        {
            var result = await TodoService.GetAllAsync();

            var model = result.Select(i => new TodoViewModel {
                Id = i.Id,
                Content = i.Content,
                Done = i.Done,
            });

            return View(model);
        }

        [HttpPost]
        [TempViewDataActionFilter(TempDataKey = "_AddTodoForm")]
        public async Task<ActionResult> Add(AddTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await TodoService.CreateAsync(model.Content);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<ActionResult> Complete(int id)
        {
            if (ModelState.IsValid)
            {
                await TodoService.FinishAsync(id);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<ActionResult> Start(int id)
        {
            if (ModelState.IsValid)
            {
                await TodoService.UnfinishAsync(id);
            }

            return RedirectToAction("index");
        }
    }
}
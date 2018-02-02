using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TodoApp.Core;
using TodoApp.Web.ActionFilters;
using TodoApp.Web.ViewModels;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        protected ITodoService TodoService { get; }
            = new Core.Services.TodoService();

        public async Task<ActionResult> Index()
        {
            var result = await TodoService.GetTodoItemsAsync();

            var model = result.Select(i => new TodoViewModel {
                Id = i.Id,
                Content = i.Content
            });

            return View(model);
        }

        [TempViewDataActionFilter(TempDataKey = "_AddTodoForm")]
        public ActionResult Add(AddTodoViewModel model)
        {
            return RedirectToAction("index");
        }

        public ActionResult Complete(int id)
        {
            return RedirectToAction("index");
        }
    }
}
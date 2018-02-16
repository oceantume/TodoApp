using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TodoApp.Core;
using TodoApp.Core.Todo;
using TodoApp.Web.Filters;
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

        [HttpGet]
        [Route(""), Route("Index")]
        public async Task<ActionResult> Index()
        {
            var result = await TodoService.GetAllAsync();

            var model = result.Select(i => new TodoViewModel {
                Id = i.Id,
                Content = i.Content,
                Checked = i.Checked,
            });

            return View(model);
        }
        
        [HttpPost]
        [Route(""), Route("Index")]
        [OnFormKeyValue("form-action", "check")]
        public async Task<ActionResult> Index_Check(CheckTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await TodoService.SetCheckedAsync(model.Id, model.Checked);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route(""), Route("Index")]
        [OnFormKeyValue("form-action", "add")]
        [TempViewDataActionFilter(TempDataKey = "_AddTodoForm")]
        public async Task<ActionResult> Index_Add(AddTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await TodoService.CreateAsync(model.Content);
            }

            return RedirectToAction("index");
        }
    }
}
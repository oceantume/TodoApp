using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Web.ActionFilters;
using TodoApp.Web.ViewModels;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<TodoViewModel> {
                new TodoViewModel { Id = 1, Content = "First item" },
                new TodoViewModel { Id = 2, Content = "Second item" },
                new TodoViewModel { Id = 3, Content = "Third item" },
            };

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
﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TodoApp.Core;
using TodoApp.Core.Requests;
using TodoApp.Core.Todo;
using TodoApp.Web.Filters;
using TodoApp.Web.ViewModels;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private IMediator Mediator { get; }

        public TodoController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [Route(""), Route("Index")]
        public async Task<ActionResult> Index()
        {
            var result = await Mediator.Send(new GetAllTodosRequest { });

            var model = result.Select(i => new TodoViewModel {
                Id = i.Id,
                Content = i.Content,
                Checked = i.Checked,
            });

            return View(model);
        }

        [HttpPost]
        [Route(""), Route("Index")]
        [OnFormKey("submit-check")]
        public async Task<ActionResult> Index_Check(CheckTodoFormModel model)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new CheckTodoRequest { TodoId = model.Id, Checked = true });
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route(""), Route("Index")]
        [OnFormKey("submit-uncheck")]
        public async Task<ActionResult> Index_Uncheck(CheckTodoFormModel model)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new CheckTodoRequest { TodoId = model.Id, Checked = false });
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route(""), Route("Index")]
        [OnFormKey("submit-add")]
        [TempViewDataActionFilter(TempDataKey = "_AddTodoForm")]
        public async Task<ActionResult> Index_Add(AddTodoFormModel model)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new CreateTodoRequest { Content = model.Content });
            }

            return RedirectToAction("index");
        }
    }
}
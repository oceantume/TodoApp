using System.Web.Mvc;

namespace TodoApp.Web.ActionFilters
{
    public class TempViewDataActionFilter : ActionFilterAttribute
    {
        public string TempDataKey { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.TempData[TempDataKey] = filterContext.Controller.ViewData;
        }
    }
}
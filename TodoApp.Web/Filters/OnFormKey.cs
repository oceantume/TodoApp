using System.Reflection;
using System.Web.Mvc;

namespace TodoApp.Web.Filters
{
    public class OnFormKey : ActionMethodSelectorAttribute
    {
        private string _key { get; set; }

        public OnFormKey(string key)
        {
            _key = key;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request.Form[_key] != null;
        }
    }
}
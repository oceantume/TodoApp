using System.Reflection;
using System.Web.Mvc;

namespace TodoApp.Web.Filters
{
    public class OnFormKeyValue : ActionMethodSelectorAttribute
    {
        private string _value { get; set; }
        private string _key { get; set; }

        public OnFormKeyValue(string key, string value) {
            _value = value;
            _key = key;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request.Form[_key] == _value;
        }
    }
}
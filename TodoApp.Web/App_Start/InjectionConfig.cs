using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace TodoApp.Web
{
    public static class InjectionConfig
    {
        public static void Configure()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterTodoAppTypes();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterTodoAppTypes(this Container container)
        {
            container.Register<Core.ITodoService, Core.Services.TodoService>(Lifestyle.Scoped);
        }
    }
}
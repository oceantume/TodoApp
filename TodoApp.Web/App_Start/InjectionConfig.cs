using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using TodoApp.Core.Requests;

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
            container.RegisterMediator();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterTodoAppTypes(this Container container)
        {
            container.Register<Core.Todo.ITodoStorageService, Core.Storage.InMemoryTodoStorageService>(Lifestyle.Singleton);
        }

        private static void RegisterMediator(this Container container)
        {
            var assemblies = GetAssemblies();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IRequestHandler<>), assemblies);

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
            container.RegisterCollection(typeof(INotificationHandler<>), notificationHandlerTypes);

            // replace the following to support pipelines
            container.RegisterCollection(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(CreateTodoRequest).GetTypeInfo().Assembly;
        }
    }
}
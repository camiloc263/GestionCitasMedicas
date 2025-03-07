using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;

using System.Web.Http;
using System.Web.Mvc;

using Persona.Infrastructure.Repository;
using Persona.Application.Services;
using Persona.Domain.Interface;
using MediatR;
using System;
using AutoMapper;
using System.Linq;

namespace Persona
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //registro de dependencias
            RegisterDependencies(container);
            //registro de controladores
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //Verifica la configuracion
            container.Verify();
            // COnfigurar web api
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        private void RegisterDependencies(Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registro de dependencias de la aplicación
            container.Register<PersonaContext>(Lifestyle.Scoped);
            container.Register<IPersonaServices, PersonaServices>(Lifestyle.Scoped);
            container.Register<IPersonaRepository, PersonaRepository>(Lifestyle.Scoped);

            // Registrar AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });
            container.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

            // Registrar ServiceFactory como Singleton
            container.RegisterSingleton<ServiceFactory>(() => type => container.GetInstance(type));

            // Registrar IMediator correctamente
            container.RegisterSingleton<IMediator>(() =>
                new Mediator(container.GetInstance<ServiceFactory>()));

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var requestHandlers = assemblies.SelectMany(a => a.GetTypes())
                                    .Where(t => !t.IsAbstract && !t.IsInterface) // Solo clases concretas
                                    .Where(t => t.GetInterfaces()
                                                 .Any(i => i.IsGenericType &&
                                                           i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

            foreach (var handler in requestHandlers)
            {
                var handlerInterface = handler.GetInterfaces()
                                              .First(i => i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                container.Register(handlerInterface, handler, Lifestyle.Transient);
            }

        
            container.Collection.Register(typeof(INotificationHandler<>), assemblies);

       
            container.Collection.Register(typeof(IPipelineBehavior<,>), assemblies);




        }

    }
    }



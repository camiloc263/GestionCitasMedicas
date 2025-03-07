using CitasMedicas.Application.Services;
using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Messaging;
using CitasMedicas.Infrastructure.Repository;
using RabbitMQ.Client;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CitasMedicas
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
            // 1️⃣ Registrar IConnectionFactory primero
            container.Register<IConnectionFactory>(() => new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"

                                
            }, Lifestyle.Scoped);

            // 2️⃣ Registrar RabbitMQProduce correctamente
            container.Register<RabbitMQProduce>(Lifestyle.Scoped);

            // 3️⃣ Registrar otros servicios
            container.Register<CitaMedicaContext>(Lifestyle.Scoped);
            container.Register<ICitaMedicaServices, CitaMedicaServices>(Lifestyle.Scoped);
            container.Register<ICitaMedicaRepository, CitaMedicaRepository>(Lifestyle.Scoped);
            container.Register<HttpClient>(() => new HttpClient { BaseAddress = new Uri("https://localhost:44381/api/persona") }, Lifestyle.Scoped);
            container.Register<PersonaClient>(Lifestyle.Scoped);
           



        }

    }
}

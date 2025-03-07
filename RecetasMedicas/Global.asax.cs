using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RecetasMedicas.Infrastructure.Repository;
using RecetasMedicas.Application.Services;
using RecetasMedicas.Domain.Interfaces;
using RecetasMedicas.Infrastructure.Messaging;
using System.Threading.Tasks;
using Microsoft.Win32;
using CitasMedicas.Application.Services;
using CitasMedicas.Infrastructure.Messaging;
using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Repository;
using System.Net.Http;
using RabbitMQ.Client;
using RecetasMedicas.Infrastructure.Controllers;

namespace RecetasMedicas
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

          RunBackgroundTasks(container);

        }

        private void RegisterDependencies(Container container)
        {  
            container.Register<IConnectionFactory>(() => new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            }, Lifestyle.Singleton);

            container.Register<RabbitMQProduce>(Lifestyle.Scoped);
            container.Register<RabbitMQConsumer>(Lifestyle.Scoped);

            
            container.Register<CitaMedicaContext>(Lifestyle.Scoped);  // ✅ Agregado
            container.Register<FormulaMedicaContext>(Lifestyle.Scoped);

           
            container.Register<ICitaMedicaRepository, CitaMedicaRepository>(Lifestyle.Scoped);
            container.Register<IFormulaMedicaRepository, FormulaMedicaRepository>(Lifestyle.Scoped);

            container.Register<ICitaMedicaServices, CitaMedicaServices>(Lifestyle.Scoped);
            container.Register<IFormulaMedicaServices, FormulaMedicaServices>(Lifestyle.Scoped);

            container.Register<PersonaClient>(() => new PersonaClient(new HttpClient()), Lifestyle.Singleton);


        }

        private async Task RunBackgroundTasks(Container container)
        {
            using (AsyncScopedLifestyle.BeginScope(container))
            {
                var receptorMQ = container.GetInstance<RabbitMQConsumer>();
                await Task.Run(() => receptorMQ.Escuchar());
            }

        }



    }

}


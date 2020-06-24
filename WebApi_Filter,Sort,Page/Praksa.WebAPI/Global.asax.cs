using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using ProjectRepository;
using ProjectService;
using Praksa.WebAPI.Controllers;
using AutoMapper;
using ProjectModel;
using PraksaWebApi.Models;

namespace Praksa.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<StudentController>();
            containerBuilder.RegisterModule<StudentServiceDiModule>();
            containerBuilder.RegisterModule<StudentRepositoryDiModule>();

            /*automapper:*/
            containerBuilder.RegisterType<StudentModel>().AsSelf();
            containerBuilder.RegisterType<Student>().AsSelf();

            containerBuilder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentModel>().ReverseMap();

            })).AsSelf().SingleInstance();

            containerBuilder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();/*:automapper*/

            var container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }

    }
}

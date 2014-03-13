using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Autofac.Integration.WebApi;
using System.Web.Http;
using RazApp.Domain.Repository.Repository;
using RazApp.Service.Services;
using RazApp.Web.Mappings;
using RazApp.Data.Infrastructure;
using System.Data.Entity;
using RazApp.Data.DatabaseContext;
using RazApp.Web.App_Start;
using RazApp.Data.Migrations;

namespace RazApp.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            MigrationConfig.MigrateOrSeed();              

            SetAutofacContainerForMvcWeb();

            SetAutofacContainerForWebAPI();
                        
            AutoMapperConfiguration.Configure();
        }

        #region Autofac Container For Web
        private static void SetAutofacContainerForMvcWeb()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();

            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerHttpRequest();


            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        #endregion

        #region Autofac Container For WebAPI
        private static void SetAutofacContainerForWebAPI()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();

            // Register other dependencies.
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerHttpRequest();

            // Build the container.
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
        #endregion

       
    }
}
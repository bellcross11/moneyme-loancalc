using Autofac;
using Autofac.Integration.WebApi;
using LoanCalculator.DataAccess.Core;
using LoanCalculator.DataAccess.Core.IRepositories;
using LoanCalculator.DataAccess.Persistence;
using LoanCalculator.DataAccess.Persistence.EFContext;
using LoanCalculator.DataAccess.Persistence.Repositories;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace LoanCalculator.Application.Web.Configurations
{
    public class IocConfig
    {
        public static IContainer Container;

        // Call this method in GlobalAsax for dependency injection
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            //builder.RegisterType<LoanRepository>().As<ILoanRepository>().SingleInstance();
            //builder.RegisterInstance<DbContext>(new LoanDBContext()).SingleInstance();

            var container = builder.Build();

            return container;
        }
    }
}
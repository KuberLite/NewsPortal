using NewsPortal.Domain.Context;
using NewsPortal.NewsFeedSources;
using NewsPortal.NewsFeedSources.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace NewsPortal.DependencyInjection
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            kernel.Unbind<ModelValidatorProvider>();

            BindApplicationContext();
            BindNewsSources();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void BindApplicationContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NewsContext"];
            kernel.Bind<NewsContext>().ToSelf().WithConstructorArgument(connectionString);
        }

        private void BindNewsSources()
        {
            kernel.Bind<IHabraHabrFetcher>().To<HabraHabrFetcher>();
            kernel.Bind<IInterfaxFetcher>().To<InterfaxFetcher>();
        }
    }
}

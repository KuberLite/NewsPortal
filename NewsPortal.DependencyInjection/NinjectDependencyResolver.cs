using AutoMapper;
using NewsPortal.DependencyInjection.Providers;
using NewsPortal.Domain.Context;
using NewsPortal.NewsFeedSources;
using NewsPortal.NewsFeedSources.Interfaces;
using NewsPortal.Services.Concrete;
using NewsPortal.ServicesFacade.Concrete;
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

            BindAutoMapper();
            BindNewsSources();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NewsContext"].ConnectionString;
            kernel.Bind<NewsContext>().ToSelf()
                .WithConstructorArgument("connectionString", connectionString);

            kernel.Bind(typeof(INewsService)).To(typeof(NewsService));
        }

        private void BindAutoMapper()
        {
            kernel.Bind<IMapper>().ToProvider<AutoMapperProvider>()
                .InSingletonScope();
        }

        private void BindNewsSources()
        {
            kernel.Bind<IHabraHabrFetcher>().To<HabraHabrFetcher>();
            kernel.Bind<IInterfaxFetcher>().To<InterfaxFetcher>();
        }
    }
}

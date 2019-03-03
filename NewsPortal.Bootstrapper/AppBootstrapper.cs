using NewsPortal.DependencyInjection;
using System.Web.Mvc;

namespace NewsPortal.Bootstrapper
{
    public static class AppBootstrapper
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            return new NinjectDependencyResolver();
        }
    }
}

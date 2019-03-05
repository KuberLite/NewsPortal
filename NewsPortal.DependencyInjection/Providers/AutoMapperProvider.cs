using AutoMapper;
using Ninject.Activation;
using System;
using System.Linq;

namespace NewsPortal.DependencyInjection.Providers
{
    public class AutoMapperProvider : Provider<IMapper>
    {
        protected override IMapper CreateInstance(IContext context)
        {
            var profiles = ViewModel.AssemblyProvider.GetAssembly
                .GetTypes()
                .Where(type => type.BaseType == typeof(Profile));

            return new MapperConfiguration(exp => exp.AddProfiles(profiles))
                .CreateMapper();
        }
    }
}

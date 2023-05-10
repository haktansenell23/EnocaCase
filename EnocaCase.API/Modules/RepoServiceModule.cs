using Autofac;
using EnocaCase.Core.Repositories;
using EnocaCase.Core.Services;
using EnocaCase.Core.UnitOfWork;
using EnocaCase.Repository;
using EnocaCase.Repository.Repositories;
using EnocaCase.Repository.UnitOfWork;
using EnocaCase.Service.Exceptions;
using EnocaCase.Service.Services.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace EnocaCase.API.Modules
{
    public class RepoServiceModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CarrierConfigurationService>().As<ICarrierConfigurationService>().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            var serviceAssembly = Assembly.GetAssembly(typeof(ClientSideException));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}

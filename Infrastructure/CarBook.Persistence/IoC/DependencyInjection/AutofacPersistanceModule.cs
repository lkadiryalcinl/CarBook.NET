using Autofac;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories;

namespace CarBook.Persistence.IoC.DependencyInjection
{
    public class AutofacPersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarBookContext>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
        }
    }
}

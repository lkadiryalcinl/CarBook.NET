using Autofac;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories;
using CarBook.Application.Interfaces.BlogInterfaces;
using BlogBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBook.Application.Interfaces.TagCloudInterfaces;

namespace CarBook.Persistence.IoC.DependencyInjection
{
    public class AutofacPersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Main Context Registiration
            builder.RegisterType<CarBookContext>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();

            //Mediator Registirations
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CarPricingRepository>().As<ICarPricingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TagCloudRepository>().As<ITagCloudRepository>().InstancePerLifetimeScope();

        }
    }
}

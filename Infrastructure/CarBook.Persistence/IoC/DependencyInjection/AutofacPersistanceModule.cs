using Autofac;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories;
using CarBook.Application.Interfaces.BlogInterfaces;
using BlogBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Persistence.Repositories.StatisticRepositories;
using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Application.Interfaces.AuthInterfaces;
using CarBook.Persistence.Repositories.AuthRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Application.Interfaces.CarFeatureInterfaces;

namespace CarBook.Persistence.IoC.DependencyInjection
{
    public class AutofacPersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Mediator Registirations
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CarPricingRepository>().As<ICarPricingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TagCloudRepository>().As<ITagCloudRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StatisticRepository>().As<IStatisticsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RentACarRepository>().As<IRentACarRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CarFeatureRepository>().As<ICarFeatureRepository>().InstancePerLifetimeScope();

        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool;
using LanguageSchool.Command;
using LanguageSchool.Command.Course;
using LanguageSchool.Query;

namespace LanguageSchool.Infrastructure
{
    public static class MediatorConfiguration
    {
        public static void ConfigureMediator(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            containerBuilder
                .Register(factory =>
                {
                    var lifetimeScope = factory.Resolve<ILifetimeScope>();
                    return new AutofacDependencyResolver(lifetimeScope.BeginLifetimeScope());
                })
                .As<IDependencyResolver>()
                .InstancePerLifetimeScope();

            var handlersAssembly = typeof(AddCourseCommandHandler).Assembly;

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();
        }
    }
}

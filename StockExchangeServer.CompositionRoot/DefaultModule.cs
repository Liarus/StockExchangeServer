using Autofac;
using StockExchangeServer.Domain.Quotes.Repository;
using StockExchangeServer.Domain.SharedKernel.Commands;
using StockExchangeServer.Domain.SharedKernel.Event;
using StockExchangeServer.Domain.SharedKernel.Query;
using StockExchangeServer.Infrastructure;
using StockExchangeServer.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StockExchangeServer.CompositionRoot
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterEvents(builder);
            RegisterCommands(builder);
            RegisterQueries(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterEvents(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new EventDispatcher(context);
            })
            .As<IEventDispatcherAsync>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("StockExchangeServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new CommandDispatcher(context);
            })
            .As<ICommandDispatcherAsync>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("StockExchangeServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>));
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new QueryDispatcher(context);
            })
            .As<IQueryDispatcherAsync>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("StockExchangeServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<QuoteRepository>()
                .As<IQuoteRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<SavingTypeRepository>()
            //    .As<ISavingTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ExpenseTypeRepository>()
            //    .As<IExpenseTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EntityFrameworkRepository<,>))
            //    .As(typeof(IRepository<,>));
        }
    }
}

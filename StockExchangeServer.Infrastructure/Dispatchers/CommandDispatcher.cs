using Autofac;
using StockExchangeServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcherAsync
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task SendAsync<TCommand>(TCommand command, 
            CancellationToken cancellationToken) where TCommand : ICommand
        {
            ICommandHandlerAsync<TCommand> handler;

            if (_componentContext.TryResolve(out handler))
            {
                await handler.HandleAsync(command, cancellationToken);
            }
            else
            {
                throw new HandlerNotFoundException(command.GetType().Name, nameof(CommandDispatcher));
            }
        }
    }
}

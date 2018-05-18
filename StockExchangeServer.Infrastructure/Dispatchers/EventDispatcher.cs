﻿using Autofac;
using StockExchangeServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Infrastructure
{
    public class EventDispatcher : IEventDispatcherAsync
    {
        private readonly IComponentContext _componentContext;
        private List<Delegate> _actions;

        public EventDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void ClearCallbacks()
        {
            _actions = null;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, 
            CancellationToken cancellationToken = default(CancellationToken)) where TEvent : IEvent
        {
            ICollection<IEventHandlerAsync<TEvent>> handlers;
            if (_componentContext.TryResolve(out handlers))
            {
                var tasks = new List<Task>();

                foreach (var asyncHandler in handlers)
                {
                    tasks.Add(asyncHandler.HandleAsync(@event, cancellationToken));
                }

                await Task.WhenAll(tasks);
            }
            else
            {
                throw new HandlerNotFoundException(@event.GetType().Name, nameof(EventDispatcher));
            }
        }
    }
}

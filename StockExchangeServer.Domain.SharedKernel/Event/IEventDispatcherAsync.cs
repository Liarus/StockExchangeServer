using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Event
{
    public interface IEventDispatcherAsync
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken)) 
            where TEvent : IEvent;
    }
}

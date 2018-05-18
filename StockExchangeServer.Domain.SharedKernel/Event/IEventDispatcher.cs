using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Event
{
    public interface IEventDispatcher
    {
        void Publish<TEvent>(TEvent @event) 
            where TEvent : IEvent;
    }
}

using StockExchangeServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.SharedKernel.Object
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IEvent> Events { get; }

        void ClearEvents();

        IEvent[] FlushUncommitedEvents();
    }
}

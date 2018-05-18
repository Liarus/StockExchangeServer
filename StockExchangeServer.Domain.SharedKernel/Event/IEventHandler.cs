using StockExchangeServer.Domain.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.SharedKernel.Event
{
    public interface IEventHandler<in T> : IMessageHandler<T> where T: IEvent
    {
    }
}

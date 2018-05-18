using StockExchangeServer.Domain.SharedKernel.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Messages
{
    public interface IMessageHandler<in T> where T : IMessage
    {
        void Handle(T message);
    }
}

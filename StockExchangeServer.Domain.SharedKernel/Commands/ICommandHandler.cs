using StockExchangeServer.Domain.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.SharedKernel.Commands
{
    public interface ICommandHandler<in T> : IMessageHandler<T> where T : ICommand
    {
    }
}

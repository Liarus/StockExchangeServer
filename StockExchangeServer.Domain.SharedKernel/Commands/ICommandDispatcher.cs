using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Commands
{
    public interface ICommandDispatcher
    {
        void Send<TCommand>(TCommand command) 
            where TCommand : ICommand;
    }
}

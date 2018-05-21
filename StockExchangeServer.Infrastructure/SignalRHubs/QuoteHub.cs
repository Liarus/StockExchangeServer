using Microsoft.AspNetCore.SignalR;
using StockExchangeServer.Domain.Quotes.Command;
using StockExchangeServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeServer.Infrastructure.SignalRHubs
{
    public class QuoteHub : Hub
    {
        private readonly ICommandDispatcherAsync _commandDispatcher;

        public QuoteHub(ICommandDispatcherAsync commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task StartBroadcasting()
        {
            await _commandDispatcher.SendAsync<RequestQuotesCommand>(new RequestQuotesCommand(DateTime.Now));
        }
    }
}

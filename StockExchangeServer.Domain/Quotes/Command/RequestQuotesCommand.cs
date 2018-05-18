using StockExchangeServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.Quotes.Command
{
    public class RequestQuotesCommand : BaseCommand
    {
        public readonly DateTime Timestamp;

        public RequestQuotesCommand(DateTime timestamp)
        {
            this.Timestamp = timestamp;
        }
    }
}

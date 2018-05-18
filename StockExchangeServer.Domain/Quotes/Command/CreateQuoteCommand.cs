using StockExchangeServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.Quotes.Command
{
    public class CreateQuoteCommand : BaseCommand
    {
        public readonly string Symbol;

        public readonly decimal Price;

        public readonly DateTime Timestamp;

        public CreateQuoteCommand(string symbol, decimal price, DateTime timestamp)
        {
            this.Symbol = symbol;
            this.Price = price;
            this.Timestamp = timestamp;
        }
    }
}

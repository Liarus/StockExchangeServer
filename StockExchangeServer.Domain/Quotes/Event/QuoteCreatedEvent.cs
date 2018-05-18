using StockExchangeServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.Quotes.Event
{
    public class QuoteCreatedEvent : BaseEvent
    {
        public readonly string Symbol;

        public readonly decimal Price;

        public readonly DateTime Timestamp;

        public QuoteCreatedEvent(Guid identity, string symbol, decimal price, DateTime timestamp)
            :base(identity)
        {
            this.Symbol = symbol;
            this.Price = price;
            this.Timestamp = timestamp;
        }
    }
}

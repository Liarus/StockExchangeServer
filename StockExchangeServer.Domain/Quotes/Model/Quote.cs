using StockExchangeServer.Domain.Quotes.Event;
using StockExchangeServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.Quotes.Model
{
    public class Quote : AggregateRoot
    {
        public string Symbol { get; protected set; }

        public decimal Price { get; protected set; }

        public DateTime Timestamp { get; protected set; }

        public static Quote Create(Guid identity, string symbol, decimal price, DateTime timestamp)
            => new Quote(identity, symbol, price, timestamp);

        public Quote Modify(decimal price, DateTime timestamp)
        {
            this.Price = price;
            this.Timestamp = timestamp;
            this.ApplyEvent(new QuoteModifiedEvent(this.Id, this.Symbol, price, timestamp));
            return this;
        }

        protected Quote(Guid identity, string symbol, decimal price, DateTime timestamp)
        {
            this.Id = identity;
            this.Symbol = symbol;
            this.Price = price;
            this.Timestamp = timestamp;
            this.ApplyEvent(new QuoteCreatedEvent(identity, symbol, price, timestamp));
        }

        protected Quote()
        {

        }
    }
}

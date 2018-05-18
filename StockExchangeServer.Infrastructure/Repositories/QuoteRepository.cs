using StockExchangeServer.Domain.Quotes.Model;
using StockExchangeServer.Domain.Quotes.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Infrastructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        public async Task<ICollection<Quote>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var rand = new Random();
            var quotes = new List<Quote>
            {
                Quote.Create(Guid.NewGuid(), "POL", new decimal(rand.NextDouble()), DateTime.Now),
                Quote.Create(Guid.NewGuid(), "ENC", new decimal(rand.NextDouble()), DateTime.Now),
                Quote.Create(Guid.NewGuid(), "WIG", new decimal(rand.NextDouble()), DateTime.Now),
            };
            return await Task.FromResult(quotes);
        }
    }
}

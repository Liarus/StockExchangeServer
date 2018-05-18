using StockExchangeServer.Domain.Quotes.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.Quotes.Repository
{
    public interface IQuoteRepository
    {
        Task<ICollection<Quote>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

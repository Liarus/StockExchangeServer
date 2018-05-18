using StockExchangeServer.Domain.Quotes.Command;
using StockExchangeServer.Domain.Quotes.Model;
using StockExchangeServer.Domain.Quotes.Repository;
using StockExchangeServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Application.Quotes.Saga
{
    public class QuotesRequestSaga : ICommandHandlerAsync<RequestQuotesCommand>                        
    {
        private readonly IQuoteRepository _quotes;
        private readonly ConcurrentDictionary<string, Quote> _savedQuotes = new ConcurrentDictionary<string, Quote>();
        private readonly object _updateQuotesLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Timer _timer;

        public QuotesRequestSaga()
        {
            _timer = new Timer(UpdateQuotes, null, _updateInterval, _updateInterval);
        }

        public async Task HandleAsync(RequestQuotesCommand message, CancellationToken token = default(CancellationToken))
        {
            var quotes = await _quotes.GetAllAsync();
            foreach (var quote in quotes)
            {
                _savedQuotes.AddOrUpdate(quote.Symbol, quote, (key, value) =>
                {
                    value.Modify(quote.Price, quote.Timestamp);
                    return value;
                });
            }
        }

        protected void UpdateQuotes(object state)
        {
            lock (_updateQuotesLock)
            {
                foreach( var quote in _savedQuotes)
                {
                    //Broadcast
                }
            }
        }
    }
}

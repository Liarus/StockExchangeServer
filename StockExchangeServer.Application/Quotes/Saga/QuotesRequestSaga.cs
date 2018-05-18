using Microsoft.AspNetCore.SignalR;
using StockExchangeServer.DataTransferObjects.Response;
using StockExchangeServer.Domain.Quotes.Command;
using StockExchangeServer.Domain.Quotes.Model;
using StockExchangeServer.Domain.Quotes.Repository;
using StockExchangeServer.Domain.SharedKernel.Commands;
using StockExchangeServer.Infrastructure.SignalRHubs;
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
        private readonly IHubContext<QuoteHub> _clients;
        private readonly IQuoteRepository _quotes;
        private readonly ConcurrentDictionary<string, QuoteDto> _savedQuotes = 
            new ConcurrentDictionary<string, QuoteDto>();
        private readonly object _updateQuotesLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Timer _timer;

        public QuotesRequestSaga(IHubContext<QuoteHub> clients, IQuoteRepository quotes)
        {
            _clients = clients;
            _quotes = quotes;
            _timer = new Timer(UpdateQuotes, null, _updateInterval, _updateInterval);
        }

        public async Task HandleAsync(RequestQuotesCommand message, CancellationToken token = default(CancellationToken))
        {
            var quotes = await _quotes.GetAllAsync();
            foreach (var quote in quotes)
            {
                _savedQuotes.AddOrUpdate(quote.Symbol, 
                    new QuoteDto
                    {
                        Symbol = quote.Symbol,
                        Price = quote.Price,
                        Timestamp = quote.Timestamp.ToShortDateString()
                    }, (key, value) =>
                {
                    value.Price = quote.Price;
                    value.Timestamp = quote.Timestamp.ToShortDateString();
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
                    BroadcastQuote(quote.Value);
                }
            }
        }

        protected void BroadcastQuote(QuoteDto quote)
        {
            _clients.Clients.All.SendAsync("updateQuote", quote);
        }
    }
}

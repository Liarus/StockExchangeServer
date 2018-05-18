using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Query
{
    public interface IQueryHandlerAsync<TQuery, TResult>  where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}

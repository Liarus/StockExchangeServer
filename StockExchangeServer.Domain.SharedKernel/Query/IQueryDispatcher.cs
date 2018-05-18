using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Query
{
    public interface IQueryDispatcher
    {
        TResult Execute<TResult>(IQuery query);
    }
}

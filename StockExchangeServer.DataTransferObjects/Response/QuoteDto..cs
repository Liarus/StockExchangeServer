using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.DataTransferObjects.Response
{
    public class QuoteDto
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }

        public string Timestamp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for Class1
/// </summarasdasdasdy>
///
///

namespace CurrencyTrader
{


    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly string url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(string url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            throw new NotImplementedException();
        }

    }
}
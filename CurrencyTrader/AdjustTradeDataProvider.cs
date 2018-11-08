using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using CurrencyTrader.Contracts;

namespace CurrencyTrader
{
    public class UrlTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        ITradeDataProvider urlProvider;

        public UrlTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeText = urlProvider.GetTradeData();
            List<string> newTrade = new List<string>();

    
            foreach (string line in tradeText)
            {
                newTrade.Add(line.Replace("GBP", "EUR"));
            }
            return newTrade;
        }


    }
}

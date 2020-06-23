using System;
using System.Collections.Generic;

namespace Wallet
{
    public class Bank
    {
        private static Random rnd = new Random();
        private Dictionary<string, double> price = new Dictionary<string, double>();

        public Bank()
        {
            price.Add("EUR-RUB", 77.5);
            price.Add("RUB-EUR", 0.01);
            price.Add("USD-RUB", 69.5);
            price.Add("RUB-USD", 0.01);
            price.Add("USD-EUR", 0.89);
            price.Add("EUR-USD", 1.12);
        }
        public Bank(Dictionary<string, double> price)
        {
            this.price = price;
        }


        public double Convert(int money, string title, string titleRes)
        {
            string key = title.ToUpper()+"-"+titleRes.ToUpper();
            if (this.price.ContainsKey(key))
            {
                return Math.Round(this.price[key] * money);
            }
            else
            {
                throw new Exception("В банке нет указанной валюты");
            }
        }
    }
}

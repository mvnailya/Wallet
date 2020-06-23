using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet
{
    public class Wallet
    {
        public Dictionary<string, int> account;
        private Bank bank;
        private PrintMoney printer = new PrintMoney();
        private Dictionary<string, int> res;

        public Wallet(Bank bank)
        {
            account = new Dictionary<string, int>();
            this.bank = bank;
        }

        public Wallet(Dictionary<string, int> res)
        {
            this.res = res;
        }

        public Dictionary<string, int> getAccount()
        {
            return account;
        }

        public void addMoney(string title, int price)
        {

            if (!account.ContainsKey(title))
                account.Add(title, price);
            else
            {
                int a = account[title];
                account[title] = a + price;
            }
            printer.print("Добавление",title, price);
        }

        public void removeMoney(string title, int price)
        {
            if (account.ContainsKey(title))
            {
                int a = account[title];
                if (a >= price)
                {
                    account[title] = a - price;
                    if (account[title] == 0)
                        account.Remove(title);
                    printer.print("Извлечение",title,price);
                }
                else
                    throw new Exception("Операция не возможна");
            }
            else
                throw new Exception("В кошельке нет указанной валюты");
        }

        public int getMoney(string title)
        {
            if (account.ContainsKey(title))
            {
                return account[title];
            }
            else
                return 0;
        }

        public int countСurrencies()
        {
            return account.Keys.Count;
        }

        public String price()
        {
            string temp = "{ ";
            foreach (KeyValuePair<string, int> el in account)
            {
                temp += el.Value + " " + el.Key + "; ";
            }
            if (temp.Length > 2)
            {
                temp = temp.Substring(0, temp.Length - 2);
                temp += " }";
            }
            else
                temp += "}";
            return temp;
        }
        
        
        public double getTotalMoney(string title)
        {
            double temp = 0;
            foreach (var account in getAccount())
            {
                if (account.Key != title)
                {
                    temp += bank.Convert(account.Value, account.Key, title);
                }
                else
                    temp += account.Value;
            }
            return temp;
        }
        
    }
}

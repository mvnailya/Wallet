using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet
{
    class PrintMoney
    {
        public String print(String operation, String currency, int amount)
        {
            if (operation.Equals("add"))
                operation = "добавлено";
            else
                operation = "извлечено";
            return "Было " + operation + ": " + amount + " " + currency;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Sell
    {

        public static double sellStock(string[,] stockInfo)
        {
            int choice = -1;
            Console.Clear();
            Console.WriteLine("Only whole stocks can be sold. Numbers will be rounded down");
            Console.WriteLine("A flat fee of $9.99 will be applied to each transaction.");
            Console.WriteLine("Which stock would you like to sell?");
            for (int i = 0; i < 25; i++)
            {

                if (stockInfo[i, 1] != "0")
                {
                    Console.WriteLine("(" + i + ") " + stockInfo[i, 0] + " " + stockInfo[i, 1] + " " + stockInfo[i, 2]);
                }

            }
            choice = Convert.ToInt32(Console.ReadLine());

            double amountToSell = Convert.ToDouble(stockInfo[choice, 1]);
            stockInfo[choice, 1] = "0";
            stockInfo[choice, 2] = null;
            Funds.balance += amountToSell - 9.99;
            return amountToSell;

        }

        /// <summary>
        /// Method to sell all stock in a portfolio. Returns amount gained from the transaction.
        /// No user input required.
        /// </summary>
        /// <returns></returns>
        public static double sellAllStock(Portfolio user)
        {
            double totalGains = 0;

            
                for (int i = 0; i < 25; i++)
                {
                    totalGains += Convert.ToDouble(user.stockInfo[i, 1]);
                    user.stockInfo[i, 1] = "0";
                    user.stockInfo[i, 2] = null;
                }
            
            Funds.balance += totalGains;
            return totalGains;

        }

        public static double getFullSellAmount(Portfolio user)
        {
            double totalGains = 0;

                for (int i = 0; i < 25; i++)
                {
                    totalGains += Convert.ToDouble(user.stockInfo[i, 1]);
                }
            
            return totalGains;

        }


    }
}







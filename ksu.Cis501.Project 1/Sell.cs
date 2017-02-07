using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Sell
    {
        /// <summary>
        /// Method that pulls up a menu that allows a stock to be sold. 
        /// </summary>
        /// <param name="stockInfo"></param>
        /// <returns></returns>
        public static double sellStock(string[,] stockInfo)
        {
            double amountToSell = 0;
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
            int numOfStocksToSell = 0;
            Console.WriteLine("How many stocks would you like to sell?");
            Console.WriteLine("You currently own " + stockInfo[choice, 2] + " stocks.");
            numOfStocksToSell = Convert.ToInt32(Console.ReadLine());
            if (numOfStocksToSell > Convert.ToInt32(stockInfo[choice, 2]))
            {
                Console.WriteLine("You do not own that many stocks!");
                Console.ReadLine();
                return 0;
            }
            else
            {
                double currentPriceOfStock = (Convert.ToDouble(stockInfo[choice, 1]) /Convert.ToDouble(stockInfo[choice, 2]));
                amountToSell = Convert.ToDouble(stockInfo[choice, 1]);
                stockInfo[choice, 1] = (Convert.ToDouble(stockInfo[choice, 1]) - (numOfStocksToSell * currentPriceOfStock)).ToString();//This line needs to be update to reflect current cost of 
                stockInfo[choice, 2] = (Convert.ToInt32(stockInfo[choice, 2]) - numOfStocksToSell).ToString();
                Funds.balance += amountToSell - 9.99;

            }

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
        
        /// <summary>
        /// Mehtod that returns the amount of money that would be gained if you were to sell all the stock in a portfolio at a specific time. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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







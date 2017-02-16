using System;
using System.Collections.Generic;
using System.IO;
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
        public static double sellStock(string[,] stockInfo, string portId)
        {

            Implement.update(Buy.fullStockInfo);
            int temp = 0;

            double amountToSell = 0;
            int choice = -1;
            Console.Clear();
            Console.WriteLine("Only whole stocks can be sold. Numbers will be rounded down");
            Console.WriteLine("A flat fee of $9.99 will be applied to each transaction.");
            Console.WriteLine("Which stock would you like to sell?");
            Console.Write("\n");
            for (int i = 0; i < stockInfo.GetLength(0); i++)
            {

                if (stockInfo[i, 1] != "0")
                {
                    Console.WriteLine("(" + i + ") " + stockInfo[i, 0] + " " + Convert.ToDouble((Buy.fullStockInfo[i, 2]).Substring(1)).ToString("0.##") + " " + stockInfo[i, 2] + "    " + "Realized Gains/(Losses): $" + ((Convert.ToDouble((Buy.fullStockInfo[i, 2]).Substring(1))) - ((Convert.ToDouble(stockInfo[i, 1])) / (Convert.ToDouble(stockInfo[i, 2])))).ToString("0.##") + " per stock.");
                    //Converted the price to a double first just so I could put back into a string that was formatted.
                    temp++;
                }

            }
            if (temp == 0)
            {
                Console.Clear();
                Console.WriteLine("No Stocks Purchased!");
                Console.ReadLine();
                return 0;
            }


            bool valid = false;
            while (!valid)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                    valid = false;
                }
            }

            int numOfStocksToSell = 0;
            Console.Clear();
            Console.WriteLine("How many stocks would you like to sell?");
            Console.WriteLine("You currently own " + stockInfo[choice, 2] + " stocks.");

            valid = false;
            while (!valid)
            {
                try
                {
                    numOfStocksToSell = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                    valid = false;
                }
            }

            Console.Clear();
            double currentPriceOfStock = Convert.ToDouble(Buy.fullStockInfo[choice, 2].Substring(1));
            if (numOfStocksToSell > Convert.ToInt32(stockInfo[choice, 2]))
            {
                Console.WriteLine("You do not own that many stocks!");
                Console.ReadLine();
                return 0;
            }
            else if (numOfStocksToSell == Convert.ToInt32(stockInfo[choice, 2]))
            {
                stockInfo[choice, 1] = "0";
                stockInfo[choice, 2] = null;

            }

            else
            {

                stockInfo[choice, 1] = (Convert.ToDouble(stockInfo[choice, 1]) / Convert.ToDouble(stockInfo[choice, 2]) * (Convert.ToInt32(stockInfo[choice, 2]) - numOfStocksToSell)).ToString();
                stockInfo[choice, 2] = (Convert.ToInt32(stockInfo[choice, 2]) - numOfStocksToSell).ToString();

            }
            Funds.balance += numOfStocksToSell * currentPriceOfStock - 9.99;

            FileInfo fi = new FileInfo("GainLoss.txt");

            using (StreamWriter sw = fi.AppendText())
            {
                if (numOfStocksToSell != 0)
                    sw.WriteLine(portId + ",S," + numOfStocksToSell + "," + stockInfo[choice, 0] + "," + currentPriceOfStock);
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
            FileInfo fi = new FileInfo("GainLoss.txt");

            Implement.update(Buy.fullStockInfo);

            for (int i = 0; i < user.stockInfo.GetLength(0); i++)
            {
                if (user.stockInfo[i, 1] != "0")
                {

                    using (StreamWriter sw = fi.AppendText())
                    {
                        sw.WriteLine(user.id + ",S," + user.stockInfo[i, 2] + "," + user.stockInfo[i, 0] + "," + Convert.ToDouble(Buy.fullStockInfo[i, 2].Substring(1)));
                    }
                }


                totalGains += Convert.ToDouble(user.stockInfo[i, 2]) * Convert.ToDouble(Buy.fullStockInfo[i, 2].Substring(1));
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

            Implement.update(Buy.fullStockInfo);

            for (int i = 0; i < user.stockInfo.GetLength(0); i++)
            {
                totalGains += Convert.ToDouble(user.stockInfo[i, 2]) * Convert.ToDouble(Buy.fullStockInfo[i, 2].Substring(1));
            }

            return totalGains;

        }


    }
}







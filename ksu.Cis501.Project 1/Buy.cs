using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Buy
    {

        static int numOfTicks = File.ReadAllLines("Ticker.txt").Count();

        public static string[] stockInfo = new string[numOfTicks];
        public static string[,] fullStockInfo = new string[numOfTicks, 3];

        /// <summary>
        /// Method that fills up the stockinfo from the text file
        /// </summary>
        public static void loadInfo()
        {
            string path = @"Ticker.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < stockInfo.Length; i++)
                {
                    stockInfo[i] = sr.ReadLine();
                }

            }

            for (int i = 0; i < stockInfo.Length; i++)
            {
                string[] temp = stockInfo[i].Split('-');

                for (int j = 0; j < 3; j++)
                    fullStockInfo[i, j] = temp[j];

            }
        }





        /// <summary>
        /// Will lookup a stock based on the user input and return the price.
        /// </summary>
        /// <returns></returns>
        public static double stockLookup(string ticker, out int stockIndex)
        {

            for (int i = 0; i < fullStockInfo.GetLength(0); i++)
            {
                if (fullStockInfo[i, 0] == ticker)
                {
                    stockIndex = i;
                    return Convert.ToDouble(fullStockInfo[i, 2].Substring(1));

                }
            }
            stockIndex = -1;
            return -1;
        }

        /// <summary>
        /// Brings up a window that will ask how a stock will be purchased and proceed to continue with said purchase. 
        /// </summary>
        public static void buyMenu(Portfolio[] portfolios)
        {


            string ticker;
            int choice = 0;
            string portName;
            int portIndex;
            int numOfStocks = -1;
            double dollarAmountofStocks = 0;
            int stockIndex;

            Console.WriteLine("Enter the id of the portfolio you would like to use");
            portName = Console.ReadLine();

            while (portName == "")
            {
                Console.WriteLine("Invalid Input");
                portName = Console.ReadLine();
            }

            Implement.update(Buy.fullStockInfo);

            if (portfolios[0].id == portName)
            {
                portIndex = 0;
            }
            else if (portfolios[1].id == portName)
            {
                portIndex = 1;
            }
            else if (portfolios[2].id == portName)
            {
                portIndex = 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a valid Portfolio ID!");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("There is a flat-fee per trade of $9.99");
            Console.WriteLine("Enter the ticker of the stock to buy: ");
            ticker = Console.ReadLine();
            Console.Clear();
            while (stockLookup(ticker, out stockIndex) == -1)
            {
                Console.WriteLine("Invalid Input");
                ticker = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Current Price per Stock: $" + stockLookup(ticker, out stockIndex).ToString("0.##"));
            Console.WriteLine("(1)Enter number of stocks to purchase.");
            Console.WriteLine("(2)Enter amount in dollars to purchase.");

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

            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter number of stocks to purchase: ");

                valid = false;
                while (!valid)
                {
                    try
                    {
                        numOfStocks = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Input");
                        valid = false;
                    }
                }

                double totalCost = (numOfStocks * stockLookup(ticker, out stockIndex) + 9.99);
                if (totalCost > Funds.balance)
                {
                    Console.Clear();
                    Console.WriteLine("Insufficient Funds!");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("Total Cost: $" + totalCost.ToString("0.##"));
                Console.ReadLine();
                Funds.balance = Funds.balance - totalCost;
                portfolios[portIndex].stockInfo[stockIndex, 1] = (Convert.ToDouble(portfolios[portIndex].stockInfo[stockIndex, 1]) + totalCost - 9.99).ToString();
                portfolios[portIndex].stockInfo[stockIndex, 2] = (Convert.ToInt32(portfolios[portIndex].stockInfo[stockIndex, 2]) + numOfStocks).ToString();

            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("NOTE: Ticker501 Does not support buying fraction stocks numbers will be rounded down.");
                Console.WriteLine("Enter dollar amount to purchase: ");

                valid = false;
                while (!valid)
                {
                    try
                    {
                        dollarAmountofStocks = Convert.ToDouble(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Input");
                        valid = false;
                    }
                }

                if (dollarAmountofStocks < stockLookup(ticker, out stockIndex))
                {
                    Console.Clear();
                    Console.WriteLine("Not enough to purchase 1 stock!");
                    Console.ReadLine();
                    return;
                }
                numOfStocks = Convert.ToInt32(Math.Floor(dollarAmountofStocks / stockLookup(ticker, out stockIndex)));
                if (numOfStocks * stockLookup(ticker, out stockIndex) + 9.99 > Funds.balance)
                {
                    Console.Clear();
                    Console.WriteLine("Insufficient Funds!");
                    Console.ReadLine();
                    return;
                }
                Console.Clear();
                Console.WriteLine("Total shares bought: " + numOfStocks);
                Funds.balance = Funds.balance - (numOfStocks * stockLookup(ticker, out stockIndex) + 9.99);

                portfolios[portIndex].stockInfo[stockIndex, 1] = (Convert.ToDouble(portfolios[portIndex].stockInfo[stockIndex, 1]) + (numOfStocks * stockLookup(ticker, out stockIndex)).ToString());
                portfolios[portIndex].stockInfo[stockIndex, 2] = (Convert.ToInt32(portfolios[portIndex].stockInfo[stockIndex, 2]) + numOfStocks).ToString();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid Option!");
                Console.ReadLine();
            }



            FileInfo fi = new FileInfo("GainLoss.txt");

            using (StreamWriter sw = fi.AppendText())
            {
                sw.WriteLine(portName + ",B," + numOfStocks + "," + ticker + "," + stockLookup(ticker, out stockIndex));
            }


        }
    }
}

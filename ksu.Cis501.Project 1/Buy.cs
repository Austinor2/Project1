using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    class Buy
    {


        string[] stockInfo = new string[25];
        public string[,] fullStockInfo = new string[25, 3];
        public Buy()
        {
            string path = @"C:\Users\Austin\Desktop\Ticker.txt";
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
        public double stockLookup(string ticker, out int stockIndex)
        {

            for(int i = 0; i < 25; i++)
            {
                if(fullStockInfo[i,0] == ticker)
                {
                    stockIndex = i;
                    return Convert.ToDouble(fullStockInfo[i, 2].Substring(1));
                    
                }
            }
            stockIndex = -1;
            return - 1;
        }

        /// <summary>
        /// Brings up a window that will ask how a stock will be purchased and proceed to continue with said purchase. 
        /// </summary>
        public void buyMenu(Portfolio[] portfolios)
        {


            string ticker;
            int choice = 0;
            string portName;
            int portIndex;
            int numOfStocks;
            double dollarAmountofStocks;
            int stockIndex;

            Console.WriteLine("Enter the id of the portfolio you would like to use");
            portName = Console.ReadLine();

            if(portfolios[0].id == portName)
            {
                portIndex = 0;
            }
            else if(portfolios[1].id == portName)
            {
                portIndex = 1;
            }
            else if(portfolios[2].id == portName)
            {
                portIndex = 2;
            }
            else
            {
                Console.WriteLine("Not a valid Portfolio ID");
                return;
            }

            Console.Clear();
            Console.WriteLine("There is a flat-fee per trade of $9.99");
            Console.WriteLine("Enter the ticker of the stock to buy: ");
            ticker = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Current Price per Stock: $" + stockLookup(ticker,out stockIndex));
            Console.WriteLine("(1)Enter number of stocks to purchase.");
            Console.WriteLine("(2)Enter amount in dollars to purchase.");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter number of stocks to purchase: ");
                numOfStocks = Convert.ToInt32(Console.ReadLine());
                double totalCost = (numOfStocks * stockLookup(ticker, out stockIndex) + 9.99);
                if(totalCost > Funds.balance)
                {
                    Console.WriteLine("Insufficient Funds");
                    return;
                }
                Console.WriteLine("Total Cost: $" + totalCost);
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
                dollarAmountofStocks = Convert.ToDouble(Console.ReadLine());
                double totalStocksBought = Math.Floor(dollarAmountofStocks / stockLookup(ticker, out stockIndex));
                if (totalStocksBought * stockLookup(ticker, out stockIndex) + 9.99 > Funds.balance)
                {
                    Console.WriteLine("Insufficient Funds");
                    return;
                }
                Console.WriteLine("Total shares bought: " + totalStocksBought);
                Funds.balance = Funds.balance - (totalStocksBought * stockLookup(ticker, out stockIndex) + 9.99);

                portfolios[portIndex].stockInfo[stockIndex, 1] = (Convert.ToDouble(portfolios[portIndex].stockInfo[stockIndex, 1]) + (totalStocksBought * stockLookup(ticker, out stockIndex)).ToString());
                portfolios[portIndex].stockInfo[stockIndex, 2] = (Convert.ToInt32(portfolios[portIndex].stockInfo[stockIndex, 2]) + totalStocksBought).ToString();

            }
            else
                Console.WriteLine("Invalid Option");


            /// <summary>
            /// Method to sell specific stocks in a portfolio. Returns amount gained from the transaction.
            /// User input required. 
            /// </summary>
            /// <returns></returns>
        




        }
    }
}

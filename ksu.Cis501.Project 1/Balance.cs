using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Balance
    {

        /// <summary>
        /// Shows cash and positions balance in dollar amount and percentage of the total account. 
        /// </summary>
        /// <param name="users">The top level portfolio used to go through all the stocks in every portfolio</param>
        public static void cashBalance(Portfolio users)
        {
            Console.Clear();
            double totalInStocks = 0;
            Console.WriteLine("Total account balance: $" + Funds.balance.ToString("0.##"));

            for (int i = 0; i < 3; i++)
            {
                totalInStocks += Sell.getFullSellAmount(users.getPortfolios[i]);
            }
            Console.WriteLine("Total amount in stocks: $" + totalInStocks.ToString("0.##"));
            Console.ReadLine();

        }


        /// <summary>
        /// Shows positions balance, the percentage of each stock in a specific portfolio,and the amount in dollars in each stock in the portfolio equivalent to selling all stocks at time of report. 
        /// </summary>
        public static void posBalance(Portfolio users)
        {
            Console.Clear();
            double totalInStocks = 0;

            for (int i = 0; i < 3; i++)
            {
                totalInStocks += Sell.getFullSellAmount(users.getPortfolios[i]);
            }
            int choice = -1;

            if (users.getPortfolios[0].id == "temp1" || users.getPortfolios[0].id == "temp2" || users.getPortfolios[0].id == "temp3")
            {
                Console.WriteLine("You have not created any portfolios yet!");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Which portfolio would you like to see: ");

                Console.WriteLine("(1)" + users.getPortfolios[0].id);

                if (users.getPortfolios[1].id != "temp1" && users.getPortfolios[1].id != "temp2" && users.getPortfolios[1].id != "temp3")
                    Console.WriteLine("(2)" + users.getPortfolios[1].id);
                if (users.getPortfolios[2].id != "temp1" && users.getPortfolios[2].id != "temp2" && users.getPortfolios[2].id != "temp3")
                    Console.WriteLine("(3)" + users.getPortfolios[2].id);



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

            }
            Console.Clear();
            Console.WriteLine("--- " + users.getPortfolios[choice - 1].id + " ---");

            Console.WriteLine("Total investment: $" + Sell.getFullSellAmount(users.getPortfolios[choice - 1]).ToString("0.##"));

            Console.WriteLine("Percentage of Account: " + (Sell.getFullSellAmount(users.getPortfolios[choice - 1]) / totalInStocks).ToString("0.##%"));


            double numberOfStocks = 0;
            for (int y = 0; y < users.getPortfolios[1].stockInfo.GetLength(0); y++)
            {

                if (users.getPortfolios[choice - 1].stockInfo[y, 2] != null)
                {
                    numberOfStocks += Convert.ToDouble(users.getPortfolios[choice - 1].stockInfo[y, 2]);


                }

            }

            int o = 0;
            for (int i = 0; i < users.getPortfolios[1].stockInfo.GetLength(0); i++)
            {

                if (users.getPortfolios[choice - 1].stockInfo[i, 1] != "0")
                {
                    o++;
                    Console.WriteLine("$" + Convert.ToDouble(users.getPortfolios[choice - 1].stockInfo[i, 1]).ToString("0.##") + "  -(" + ((Convert.ToDouble(users.getPortfolios[choice - 1].stockInfo[i, 2]) / numberOfStocks) * 100).ToString("0.##") + "%)" + users.getPortfolios[choice - 1].stockInfo[i, 0]);
                }

            }



            Console.ReadLine();
        }


        /// <summary>
        /// Shows the stock information across the entire account and all portfolios.
        /// </summary>
        /// <param name="users"></param>
        public static void accBalance(Portfolio users)
        {
            Console.Clear();
            double totalInStocks = 0;

            for (int i = 0; i < 3; i++)
            {
                totalInStocks += Sell.getFullSellAmount(users.getPortfolios[i]);
            }
            //int choice = -1;

            if (users.getPortfolios[0].id == "temp1" || users.getPortfolios[0].id == "temp2" || users.getPortfolios[0].id == "temp3")
            {
                Console.WriteLine("No available portfolios to display!");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            int numOfAccounts = 1;
            if (users.getPortfolios[1].id == "temp1" || users.getPortfolios[1].id == "temp2" || users.getPortfolios[1].id == "temp3")
                numOfAccounts = 1;
            else if (users.getPortfolios[2].id == "temp1" || users.getPortfolios[2].id == "temp2" || users.getPortfolios[2].id == "temp3")
                numOfAccounts = 2;
            else
                numOfAccounts = 3;




            for (int p = 0; p < numOfAccounts; p++)
            {
                Implement.update(Buy.fullStockInfo);
                Console.WriteLine("\n");
                Console.WriteLine("--- " + users.getPortfolios[p].id + " ---");

                Console.WriteLine("Total investment: $" + Sell.getFullSellAmount(users.getPortfolios[p]).ToString("0.##"));

                Console.WriteLine("Percentage of Account: " + (Sell.getFullSellAmount(users.getPortfolios[p]) / totalInStocks).ToString("0.##%"));


                double numberOfStocks = 0;
                for (int y = 0; y < (users.getPortfolios[p].stockInfo.GetLength(0)); y++)
                {

                    if (users.getPortfolios[p].stockInfo[y, 2] != null)
                    {
                        numberOfStocks += Convert.ToDouble(users.getPortfolios[p].stockInfo[y, 2]);


                    }

                }

                int o = 0;

                for (int i = 0; i < users.getPortfolios[p].stockInfo.GetLength(0); i++)
                {

                    if (users.getPortfolios[p].stockInfo[i, 1] != "0")
                    {
                        o++;
                        Console.WriteLine("$" + Convert.ToDouble(users.getPortfolios[p].stockInfo[i, 1]).ToString("0.##") + "  -(" + (Convert.ToDouble(users.getPortfolios[p].stockInfo[i, 2]) / numberOfStocks).ToString("0.##%") + ") " + users.getPortfolios[p].stockInfo[i, 0]);
                    }

                }
            }



            Console.ReadLine();
        }





        /// <summary>
        /// Shows a gain/loss report in dollar amounts based on the account.
        /// </summary>
        public static void gainLossReport()
        {

            int i = 0;
            string[,] gainLossInfo;

            string path = @"GainLoss.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                gainLossInfo = new string[File.ReadAllLines(path).Count(), 5];

                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    string[] tempArray = temp.Split(',');

                    for (int l = 0; l < 5; l++)
                        gainLossInfo[i, l] = tempArray[l];
                    i++;

                }

            }


            double gainLoss = 0;

            for (int y = 0; y < gainLossInfo.GetLength(0); y++)
            {
                string test = gainLossInfo[y, 1];
                if (test == "B")
                {
                    gainLoss -= Convert.ToDouble(gainLossInfo[y, 2]) * Convert.ToDouble(gainLossInfo[y, 4]);
                    Console.WriteLine(gainLossInfo[y, 2] + " stock(s) were bought from " + gainLossInfo[y, 3] + " at a price of $" + Convert.ToDouble(gainLossInfo[y, 4]).ToString("0.##") + " per stock.");
                }
                else if (test == "S")
                {
                    gainLoss += Convert.ToDouble(gainLossInfo[y, 2]) * Convert.ToDouble(gainLossInfo[y, 4]);
                    Console.WriteLine(gainLossInfo[y, 2] + " stock(s) were sold from " + gainLossInfo[y, 3] + " at a price of $" + Convert.ToDouble(gainLossInfo[y, 4]).ToString("0.##") + " per stock.");
                }


            }






            if (gainLoss > 0)
                Console.WriteLine("\nTotal Gains: $" + gainLoss.ToString("0.##"));
            else if (gainLoss < 0)
                Console.WriteLine("\nTotal Losses: $" + (gainLoss * -1.0).ToString("0.##"));
            else
                Console.WriteLine("\nTotal Gains: $0.00");




            Console.ReadLine();



        }




        /// <summary>
        /// Shows a gainloss report for a specific portfolio that is passed in as a parameter.
        /// </summary>
        /// <param name="user"></param>
        public static void gainLossReport(Portfolio user)
        {

            int i = 0;
            string[,] gainLossInfo;

            string path = @"GainLoss.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                gainLossInfo = new string[File.ReadAllLines(path).Count(), 5];

                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    string[] tempArray = temp.Split(',');

                    for (int l = 0; l < 5; l++)
                        gainLossInfo[i, l] = tempArray[l];
                    i++;

                }

            }


            double gainLoss = 0;

            for (int y = 0; y < gainLossInfo.GetLength(0); y++)
            {
                if (gainLossInfo[y, 0] == user.id)
                {
                    string test = gainLossInfo[y, 1];
                    if (test == "B")
                    {
                        gainLoss -= Convert.ToDouble(gainLossInfo[y, 2]) * Convert.ToDouble(gainLossInfo[y, 4]);
                        Console.WriteLine(gainLossInfo[y, 2] + " stock(s) were bought from " + gainLossInfo[y, 3] + " at a price of $" + Convert.ToDouble(gainLossInfo[y, 4]).ToString("0.##") + " per stock.");
                    }
                    else if (test == "S")
                    {
                        gainLoss += Convert.ToDouble(gainLossInfo[y, 2]) * Convert.ToDouble(gainLossInfo[y, 4]);
                        Console.WriteLine(gainLossInfo[y, 2] + " stock(s) were sold from " + gainLossInfo[y, 3] + " at a price of $" + Convert.ToDouble(gainLossInfo[y, 4]).ToString("0.##") + " per stock.");
                    }
                }


            }






            if (gainLoss > 0)
                Console.WriteLine("\nTotal Gains: $" + gainLoss.ToString("0.##"));
            else if (gainLoss < 0)
                Console.WriteLine("\nTotal Losses: $" + (gainLoss * -1.0).ToString("0.##"));
            else
                Console.WriteLine("\nTotal Gains: $0.00");




            Console.ReadLine();



        }



    }
}

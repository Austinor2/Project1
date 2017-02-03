using System;
using System.Collections.Generic;
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
            double totalInStocks = 0;
            Console.WriteLine("Total account balance: $" + Funds.balance);
            
            for(int i = 0; i < 3; i++)
            {
                totalInStocks += Sell.getFullSellAmount(users.getPortfolios[i]);
            }
            Console.WriteLine("Total amount in stocks: $" + totalInStocks);
            Console.ReadLine(); 

        }


        /// <summary>
        /// Shows positions balance, the percentage of each stock in the account,and the amount in dollars in each stock in the account equivalent to selling all stocks at time of report. 
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

            if (users.getPortfolios[0].id == "temp1")
            {
                Console.WriteLine("You have not created any portfolios yet!");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Which portfolio would you like to see: ");

                Console.WriteLine("(1)" + users.getPortfolios[0].id);

                if (users.getPortfolios[1].id != "temp2")
                    Console.WriteLine("(2)" + users.getPortfolios[1].id);
                if (users.getPortfolios[2].id != "temp3")
                    Console.WriteLine("(3)" + users.getPortfolios[2].id);

                choice = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("--- " + users.getPortfolios[choice - 1].id + " ---");

            Console.WriteLine("Total investment: $" + Sell.getFullSellAmount(users.getPortfolios[choice - 1]));

            Console.WriteLine("Percentage of Account: " + (Sell.getFullSellAmount(users.getPortfolios[choice - 1]) / totalInStocks) * 100  + "%");
            Console.ReadLine();
        }


        /// <summary>
        /// Shows a gain/loss report in dollar amounts based on Period(Start/end date)
        /// </summary>
        public static void gainLossReport()
        {


        }






    }
}

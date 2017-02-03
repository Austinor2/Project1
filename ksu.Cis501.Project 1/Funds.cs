using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Funds
    {
        public static double balance { get; set; }

        public static double getBalance
        {
              get
            {
                return balance;
            }
        }
        /// <summary>
        /// Used to add money to the account
        /// </summary>
        /// <returns></returns>
        public static double add()
        {
            Console.Clear();
            Console.WriteLine("There is a flat-fee per transfer of $4.99");
            Console.WriteLine("Current Balance: $" + getBalance);
            Console.WriteLine("How much money would you like to add: ");
            balance += Convert.ToDouble(Console.ReadLine()) - 4.99;
            Console.Clear();
            Console.WriteLine("Current Balance: $" + getBalance);
            Console.ReadLine();
            return balance;
        }

        /// <summary>
        /// Used to withdrawl money from account. Also can be used to call another method to sell a stock in order to withdrawl
        /// the requested funds.
        /// </summary>
        /// <returns></returns>
        public static double withdrawl(Portfolio user)
        {
            Console.Clear();
            double amount = -1;
            Console.WriteLine("There is a flat-fee per transfer of $4.99");
            Console.WriteLine("Current Balance: $" + getBalance);
            Console.WriteLine("How much money would you like to withdrawl: ");
            amount = Convert.ToDouble(Console.ReadLine()) + 4.99;

            if(amount > getBalance + Sell.getFullSellAmount(user))
            {
                Console.Clear();
                Console.WriteLine("Insuffiecent Funds!");

            }
            else if(amount > getBalance && amount < getBalance + Sell.getFullSellAmount(user))
            {
                Console.Clear();
                Console.WriteLine("Insuffiecent Funds!");
                Console.WriteLine("What Portfolio would you like to sell from in order to fulfill the withdraw transaction?");

                Console.WriteLine("(1)" + user.getPortfolios[0].id);

                if (user.getPortfolios[1].id != "temp2")
                    Console.WriteLine("(2)" + user.getPortfolios[1].id);
                if (user.getPortfolios[2].id != "temp3")
                    Console.WriteLine("(3)" + user.getPortfolios[2].id);

                Console.WriteLine("Your new balance is: $" + Sell.sellStock(user.getPortfolios[Convert.ToInt32(Console.ReadLine()) - 1].stockInfo) + Funds.balance);
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                balance -= amount;
                Console.WriteLine("Current Balance: $" + getBalance);
                Console.ReadLine();
            }
            return balance;

        }









    }
}

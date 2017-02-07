using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = -1;
            Portfolio user = new Portfolio();
            user.getPortfolios[0] = new Portfolio("temp1");
            user.getPortfolios[1] = new Portfolio("temp2");
            user.getPortfolios[2] = new Portfolio("temp3");
            
            Buy temp6 = new Buy();

            for(int l = 0; l < 3; l++)
            {
                for(int p = 0; p < 25; p++)
                {
                    user.getPortfolios[l].stockInfo[p, 0] = temp6.fullStockInfo[p,0];
                }
            }

            while (answer != 0)
            {
               
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1)Create a Portfolio");
                Console.WriteLine("(2)Delete a Portfolio");
                Console.WriteLine("(3)Portfolio Balance(Single Portfolio)");
                Console.WriteLine("(4)Account Balance");
                Console.WriteLine("(5)Add/Withdrawl Funds");
                Console.WriteLine("(6)Buy a stock");
                Console.WriteLine("(7)Sell a stock");
                Console.WriteLine("(0)Exit");

                answer = Convert.ToInt32(Console.ReadLine());

                if (answer == 1)
                {
                    user.create();
                }
                else if (answer == 2)
                {
                    user.delete();
                }
                else if (answer == 3)
                {
                    Balance.posBalance(user);
                }
                else if (answer == 4)
                {
                    Console.Clear();
                    int p = 0;
                    Console.WriteLine("What would you like to access?");
                    Console.WriteLine("(1)Account Balance");
                    Console.WriteLine("(2)Positon Balance");
                    p = Convert.ToInt32(Console.ReadLine());

                    if(p == 1)
                    {
                        Balance.cashBalance(user);
                    }
                    else if(p == 2)
                    {
                        Balance.accBalance(user);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid option!");
                        Console.ReadLine();
                    }

                }
                else if (answer == 5)
                {
                    Console.Clear();
                    string temp = "c";
                    Console.WriteLine("(A)Add");
                    Console.WriteLine("(B)Withdrawl");
                    temp = Console.ReadLine();
                    if(temp == "A")
                    {
                        Funds.add();
                    }
                    else
                    {
                        Funds.withdrawl(user);
                    }
                    
                }
                else if(answer == 6)
                {
                    Console.Clear();

                    if(user.getPortfolios[0].id == "temp1")
                    {
                        Console.WriteLine("Must create a Portfolio first");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        temp6.buyMenu(user.getPortfolios);
                    }

                    
                }
                else if (answer == 7)
                {
                    Console.Clear();

                    int choice = 0;
                    if (user.getPortfolios[0].id == "temp1" || user.getPortfolios[0].id == "temp2" || user.getPortfolios[0].id == "temp3")
                    {
                        Console.WriteLine("You have not created any portfolios yet!");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Which portfolio would you like to access: ");

                        Console.WriteLine("(1)" + user.getPortfolios[0].id);

                        if (user.getPortfolios[1].id != "temp1" && user.getPortfolios[1].id != "temp2" && user.getPortfolios[1].id != "temp3")
                            Console.WriteLine("(2)" + user.getPortfolios[1].id);
                        if (user.getPortfolios[2].id != "temp1" && user.getPortfolios[2].id != "temp2" && user.getPortfolios[2].id != "temp3")
                            Console.WriteLine("(3)" + user.getPortfolios[2].id);

                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    if (choice == 1)
                        Sell.sellStock(user.getPortfolios[0].stockInfo);
                    else if (choice == 2)
                        Sell.sellStock(user.getPortfolios[1].stockInfo);
                    else if (choice == 3)
                        Sell.sellStock(user.getPortfolios[2].stockInfo);
                    else
                    {
                        Console.WriteLine("Invalid Option");
                        Console.ReadLine();
                    }




                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                }
                Console.Clear();
            }





            
        }
    }
}

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
                        Balance.posBalance(user);
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
                else
                {
                    Console.WriteLine("Invalid Option");
                }
                Console.Clear();
            }





            
        }
    }
}

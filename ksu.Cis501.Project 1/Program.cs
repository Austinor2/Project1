using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //This code is used to clear the file I use to keep track of my transactions.
            using (FileStream fs = File.Create("GainLoss.txt"))
            {

            }

            Implement.changeVolatility();

            Console.Clear();
            int answer = -1;
            Portfolio user = new Portfolio();
            user.getPortfolios[0] = new Portfolio("temp1");
            user.getPortfolios[1] = new Portfolio("temp2");
            user.getPortfolios[2] = new Portfolio("temp3");
            Buy.loadInfo();



            for (int l = 0; l < 3; l++)
            {
                for (int p = 0; p < user.getPortfolios[l].stockInfo.GetLength(0); p++)
                {
                    user.getPortfolios[l].stockInfo[p, 0] = Buy.fullStockInfo[p, 0];
                }
            }

            while (answer != 0)
            {
                Console.WriteLine("--WELCOME TO TICKER501--");

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1)Create a Portfolio");
                Console.WriteLine("(2)Delete a Portfolio");
                Console.WriteLine("(3)Portfolio Balance(Single Portfolio)");
                Console.WriteLine("(4)Account Balance");
                Console.WriteLine("(5)Add/Withdrawl Funds");
                Console.WriteLine("(6)Buy a stock");
                Console.WriteLine("(7)Sell a stock");
                Console.WriteLine("(8)Gain/Loss Report");
                Console.WriteLine("(9)Change Volatility of stock prices");
                Console.WriteLine("(0)Exit");
                bool valid = false;
                while (!valid)
                {
                    try
                    {
                        answer = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Input");
                        valid = false;
                    }
                }


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

                    valid = false;
                    while (!valid)
                    {
                        try
                        {
                            p = Convert.ToInt32(Console.ReadLine());
                            valid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Input");
                            valid = false;
                        }
                    }

                    if (p == 1)
                    {
                        Balance.cashBalance(user);
                    }
                    else if (p == 2)
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


                    valid = false;
                    while (!valid)
                    {
                        temp = Console.ReadLine();
                        if (temp == "A")
                        {
                            Funds.add();
                            valid = true;
                        }
                        else if (temp == "B")
                        {
                            Funds.withdrawl(user);
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            valid = false;
                        }
                    }

                }
                else if (answer == 6)
                {
                    Console.Clear();

                    if (user.getPortfolios[0].id == "temp1" || user.getPortfolios[0].id == "temp2" || user.getPortfolios[0].id == "temp3")
                    {
                        Console.WriteLine("Must create a portfolio first");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Buy.buyMenu(user.getPortfolios);
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

                    }
                    else
                    {
                        Console.WriteLine("Which portfolio would you like to access: ");

                        Console.WriteLine("(1)" + user.getPortfolios[0].id);

                        if (user.getPortfolios[1].id != "temp1" && user.getPortfolios[1].id != "temp2" && user.getPortfolios[1].id != "temp3")
                            Console.WriteLine("(2)" + user.getPortfolios[1].id);
                        if (user.getPortfolios[2].id != "temp1" && user.getPortfolios[2].id != "temp2" && user.getPortfolios[2].id != "temp3")
                            Console.WriteLine("(3)" + user.getPortfolios[2].id);


                        valid = false;
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
                            Sell.sellStock(user.getPortfolios[0].stockInfo, user.getPortfolios[0].id);
                        else if (choice == 2)
                            Sell.sellStock(user.getPortfolios[1].stockInfo, user.getPortfolios[1].id);
                        else if (choice == 3)
                            Sell.sellStock(user.getPortfolios[2].stockInfo, user.getPortfolios[2].id);
                        else
                        {
                            Console.WriteLine("Invalid Option");
                            Console.ReadLine();
                        }
                    }





                }
                else if (answer == 8)
                {
                    Console.Clear();
                    Console.WriteLine("What Gain/Loss report would you like to acces?");
                    Console.WriteLine("(1)Overall Account");

                    if (user.getPortfolios[0].id != "temp1" && user.getPortfolios[0].id != "temp2" && user.getPortfolios[0].id != "temp3")
                        Console.WriteLine("(2)" + user.getPortfolios[0].id);
                    if (user.getPortfolios[1].id != "temp1" && user.getPortfolios[1].id != "temp2" && user.getPortfolios[1].id != "temp3")
                        Console.WriteLine("(3)" + user.getPortfolios[1].id);
                    if (user.getPortfolios[2].id != "temp1" && user.getPortfolios[2].id != "temp2" && user.getPortfolios[2].id != "temp3")
                        Console.WriteLine("(4)" + user.getPortfolios[2].id);


                    int choice = 0;
                    valid = false;
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

                    Console.Clear();
                    if (choice == 1)
                        Balance.gainLossReport();
                    else if (choice == 2)
                        Balance.gainLossReport(user.getPortfolios[0]);
                    else if (choice == 3)
                        Balance.gainLossReport(user.getPortfolios[1]);
                    else if (choice == 4)
                        Balance.gainLossReport(user.getPortfolios[2]);


                }
                else if (answer == 9)
                {
                    Console.Clear();
                    Implement.changeVolatility();
                }

                else if (answer == 0)
                {
                    Console.WriteLine("Press Enter to end....");
                    Console.ReadLine();
                    return;
                }

                Console.Clear();
            }



        }
    }
}

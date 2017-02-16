using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    class Portfolio
    {

        string identifier;

        static int numOfTicks = File.ReadAllLines("Ticker.txt").Count();

        /// <summary>
        /// Index zero is the Ticker, index one is Cash per stock, index 2 is # of shares per stock. 
        /// </summary>
        public string[,] stockInfo = new string[numOfTicks, 3];


        Portfolio[] portfolios = new Portfolio[3];



        /// <summary>
        /// Default constructor
        /// </summary>
        public Portfolio()
        {

        }

        /// <summary>
        /// Sets the id for the account as well as defaults all the stock info to 0.
        /// </summary>
        /// <param name="id"></param>
        public Portfolio(string id)
        {
            identifier = id;

            for (int p = 0; p < stockInfo.GetLength(0); p++)
            {
                for (int y = 1; y < 2; y++)
                {
                    stockInfo[p, y] = "0";
                }
            }



        }


        /// <summary>
        /// Used to both get and set the id of a portfolio.
        /// </summary>
        public string id
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }

        /// <summary>
        /// Used to get the portfolios from the main portfolio account.
        /// </summary>
        public Portfolio[] getPortfolios
        {
            get
            {
                return portfolios;
            }
        }

        /// <summary>
        /// Is used to create a new portfolio for the user. Max of 3
        /// </summary>
        public void create()
        {
            string temp;
            Console.Clear();
            if (portfolios[2].id != "temp3" && portfolios[2].id != "temp2" && portfolios[2].id != "temp1")
            {
                Console.WriteLine("Maximum amount of portfolios has been reached!");
                Console.WriteLine("Please delete one to continue");
                Console.ReadLine();
            }
            else if (portfolios[0].id == "temp1" || portfolios[0].id == "temp2" || portfolios[0].id == "temp3")
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                temp = Console.ReadLine();
                while (temp == "")
                {
                    Console.WriteLine("Invalid Input");
                    temp = Console.ReadLine();
                }
                portfolios[0].identifier = temp;


            }
            else if (portfolios[1].id == "temp1" || portfolios[1].id == "temp2" || portfolios[1].id == "temp3")
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                temp = Console.ReadLine();
                while (temp == "")
                {
                    Console.WriteLine("Invalid Input");
                    temp = Console.ReadLine();
                }
                portfolios[1].identifier = temp;
            }
            else if (portfolios[2].id == "temp1" || portfolios[2].id == "temp2" || portfolios[2].id == "temp3")
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                temp = Console.ReadLine();
                while (temp == "")
                {
                    Console.WriteLine("Invalid Input");
                    temp = Console.ReadLine();
                }
                portfolios[2].identifier = temp;
            }
            return;
        }

        /// <summary>
        /// Is used to delete a portfolio and at the same time selling all positions.
        /// </summary>
        public void delete()
        {
            Console.Clear();
            int choice = 0;
            if (portfolios[0].id == "temp1" || portfolios[0].id == "temp2" || portfolios[0].id == "temp3")
            {
                Console.WriteLine("You have not created any portfolios yet!");
                Console.ReadLine();
                return;
            }
            else
            {

                Console.WriteLine("Which portfolio would you like to delete: ");

                Console.WriteLine("(1)" + portfolios[0].id);

                if (portfolios[1].id != "temp1" && portfolios[1].id != "temp2" && portfolios[1].id != "temp3")
                    Console.WriteLine("(2)" + portfolios[1].id);
                if (portfolios[2].id != "temp1" && portfolios[2].id != "temp2" && portfolios[2].id != "temp3")
                    Console.WriteLine("(3)" + portfolios[2].id);



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
            if (choice == 1)
            {
                Sell.sellAllStock(this.getPortfolios[0]);

                portfolios[0].id = portfolios[1].id;
                portfolios[0].stockInfo = portfolios[1].stockInfo;


                portfolios[1].id = portfolios[2].id;
                portfolios[1].stockInfo = portfolios[2].stockInfo;

                portfolios[2].id = "temp3";
            }
            else if (choice == 2)
            {
                Sell.sellAllStock(this.getPortfolios[1]);

                portfolios[1].id = portfolios[2].id;
                portfolios[1].stockInfo = portfolios[2].stockInfo;

                portfolios[2].id = "temp3";
            }
            else if (choice == 3)
            {
                Sell.sellAllStock(this.getPortfolios[2]);
                portfolios[2].id = "temp3";
            }
            else
            {
                Console.WriteLine("Invalid Option");
                Console.ReadLine();
            }
            return;
        }

    }
}

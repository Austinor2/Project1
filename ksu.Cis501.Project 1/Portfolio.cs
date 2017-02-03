using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    class Portfolio
    {
        
        string identifier;

        /// <summary>
        /// Index zero is the Ticker, index one is Cash per stock, index 2 is # of shares per stock. 
        /// </summary>
        public string[,] stockInfo = new string[25,3];
        

        Portfolio[] portfolios = new Portfolio[3];
        



        public Portfolio()
        {
          
        }

        public Portfolio(string id)
        {
            identifier = id;

            for (int p = 0; p < 25; p++)
            {
                for (int y = 1; y < 2; y++)
                {
                    stockInfo[p, y] = "0";
                }
            }



        }


        // Properties.
        public string id
        {
            get
            {
                return identifier;
            }
            set
            {

            }
        }


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
            Console.Clear();
            if(portfolios[2].id != "temp3")
            {
                Console.WriteLine("Maximum amount of portfolios has been reached!");
                Console.WriteLine("Please delete one to continue");
                Console.ReadLine();
            }
            else if(portfolios[0].id == "temp1")
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                portfolios[0].identifier = Console.ReadLine();

               
            }
            else if (portfolios[1].id == "temp2")
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                portfolios[1].identifier = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter the name of the portfolio: ");
                portfolios[2].identifier = Console.ReadLine();
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
            if(portfolios[0].id == "temp1")
            {
                Console.WriteLine("You have not created any portfolios yet!");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Which portfolio would you like to delete: ");

                Console.WriteLine("(1)" + portfolios[0].id);

                if (portfolios[1].id != "temp2")
                    Console.WriteLine("(2)" + portfolios[1].id);
                if (portfolios[2].id != "temp3")
                    Console.WriteLine("(3)" + portfolios[2].id);

                choice = Convert.ToInt32(Console.ReadLine());
            }
            if(choice == 1)
            {
                Sell.sellAllStock(this.getPortfolios[0]);
                portfolios[0].id = "temp1";
                portfolios[0] = portfolios[1];
                portfolios[1] = portfolios[2];
                portfolios[2].id = "temp3";
            }
            else if(choice == 2)
            {
                Sell.sellAllStock(this.getPortfolios[1]);
                portfolios[1].id = "temp2";
                portfolios[1] = portfolios[2];
                portfolios[2].id = "temp3";                
            }
            else if(choice == 3)
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

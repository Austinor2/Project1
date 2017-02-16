using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksu.Cis501.Project_1
{
    static class Implement
    {
        static int volatility = 0; // 1 is Low, 2 is Medium, 3 is High.


        /// <summary>
        /// Method to allow someone to set the volatility of the stock market. 
        /// </summary>
        /// <returns></returns>
        public static void changeVolatility()
        {

            Console.WriteLine("What Volatility would you like?");
            Console.WriteLine("(1)Low-Volatility: Prices fluctuate between 1% - 4%");
            Console.WriteLine("(2)Medium-Volatility: Prices fluctuate between 2% - 8%");
            Console.WriteLine("(3)High-Volatility: Prices fluctuate between 3% - 15%");

            bool valid = false;
            while (!valid)
            {
                try
                {
                    volatility = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                    valid = false;
                }
            }

        }

        /// <summary>
        /// Used to change the stock prices to mimic real world change.
        /// </summary>
        /// <param name="stockInfo"></param>
        public static void update(string[,] stockInfo)
        {
            Random r = new Random();

            int start = 0;
            int end = 0;

            if (volatility == 1)
            {
                start = 1;
                end = 4;
            }
            else if (volatility == 2)
            {
                start = 2;
                end = 8;
            }
            else
            {
                start = 3;
                end = 15;
            }


            for (int i = 0; i < stockInfo.GetLength(0); i++)
            {
                int function = r.Next(1, 3);//Used to change between addiction and subtraction.
                int percentNumber = r.Next(start, end + 1);

                if (function == 1)
                {
                    stockInfo[i, 2] = "$" + (Convert.ToDouble(stockInfo[i, 2].Substring(1)) + (Convert.ToDouble(stockInfo[i, 2].Substring(1)) * (percentNumber / 100.00))).ToString();
                }

                else
                {
                    stockInfo[i, 2] = "$" + (Convert.ToDouble(stockInfo[i, 2].Substring(1)) - (Convert.ToDouble(stockInfo[i, 2].Substring(1)) * (percentNumber / 100.00))).ToString();
                }


            }

        }




    }
}

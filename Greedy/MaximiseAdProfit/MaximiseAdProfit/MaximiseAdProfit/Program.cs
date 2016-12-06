using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximiseAdProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                var rnd = new Random();
                int n = //rnd.Next(1, 1000); 
                    int.Parse(Console.ReadLine());
                long[] profitPerClick = //new int[n]; 
                    Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                long[] avgClicksPerDay = //new int[n]; 
                    Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

                //for (int i = 0; i < n; i++)
                //{
                //    profitPerClick[i] = rnd.Next(-10000, 10000);
                //    avgClicksPerDay[i] = rnd.Next(-10000, 10000);
                //}

                Console.WriteLine(GetProfit(n, profitPerClick, avgClicksPerDay));
            //}
            //Console.ReadLine();
        }

        static long GetProfit(int n, long[] profitPerClick, long[] avgClicksPerDay)
        {
            Array.Sort(profitPerClick);
            Array.Sort(avgClicksPerDay);

            long result = 0;

            for(int i = n-1; i >= 0; i--)
            {
                result += (long)(profitPerClick[i] * avgClicksPerDay[i]);
            }

            return result;
        }
    }
}

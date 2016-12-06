using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine(GetNumberOfCoins(n));
            //Console.ReadLine();
        }

        private static int GetNumberOfCoins(int n)
        {
            int[] coinsNominations = new int[3] { 10, 5, 1 };
            int numberOfCoins = 0;

            for(int i = 0; i < 3; i++)
            {
                while(n >= coinsNominations[i])
                {
                    numberOfCoins++;
                    n -= coinsNominations[i];
                    if (n == 0)
                        break;
                }
            }
            return numberOfCoins;
        }
    }
}

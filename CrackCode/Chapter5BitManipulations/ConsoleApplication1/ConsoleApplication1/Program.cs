using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertBits(162, 10, 26, 29);
            Console.ReadLine();
        }

        public static int InsertBits(int n, int m, int i, int j)
        {
            Console.WriteLine(Convert.ToString(n, 2));
            Console.WriteLine(Convert.ToString(m, 2));
            Console.WriteLine(Convert.ToString(int.MaxValue, 2));
            int zerosAfterI = int.MaxValue - (1 << (31 - i)) + 1;
            Console.WriteLine(Convert.ToString(zerosAfterI, 2));
            int zerosBetweenIAndJ = zerosAfterI | (1 << (31 - j - 1)) - 1;
            Console.WriteLine(Convert.ToString(zerosBetweenIAndJ, 2));
            int res = (n & zerosBetweenIAndJ) | m << (31 - j - 1);
            Console.WriteLine(Convert.ToString(res, 2));
            return res;
        }
    }
}

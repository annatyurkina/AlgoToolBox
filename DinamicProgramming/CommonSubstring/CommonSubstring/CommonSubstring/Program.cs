using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSubstring
{
    class Program
    {
        int[,,] _dist;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            char[] exp1 = Console.ReadLine().ToCharArray();
            var m = int.Parse(Console.ReadLine());
            char[] exp2 = Console.ReadLine().ToCharArray();
            var k = int.Parse(Console.ReadLine());
            char[] exp3 = Console.ReadLine().ToCharArray();

            _dist = new int[n + 1, m + 1, k + 1];

            Console.WriteLine(LongestSub(exp1, exp2, exp3));
            Console.ReadLine();
        }
    }
}

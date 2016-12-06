using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstKPlaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                var rnd = new Random();
                int n = //rnd.Next(1, 1000000000);
                    int.Parse(Console.ReadLine());

                Console.WriteLine(GetFirstK(n));
            //}
            //Console.ReadLine();
        }

        static string GetFirstK(int n)
        {
            var sumK = n;
            List<int> prizes = new List<int>();
            for(int i=1; i <= n; i++)
            {
                sumK -= i;
                if (sumK < 0)
                {
                    prizes[i - 2] = prizes[i - 2] + sumK + i;
                    break;
                }
                prizes.Add(i);
            }

            return prizes.Count + Environment.NewLine + string.Join(" ", prizes);
        }
    }
}

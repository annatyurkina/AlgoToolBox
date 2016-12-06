using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsOfGold
{
    class Program
    {
        private static int[,] _maxValue;
        static void Main(string[] args)
        {
            var rnd = new Random();
            //while (true)
            //{
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] arrW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int W = arr[0];
                int n = arr[1];
                //int W = rnd.Next(1, 10000);
                //int n = rnd.Next(1, 300);
                //int[] arrW = GetRandomisedSortedArray(n, 10000, rnd);
                //Console.WriteLine(string.Join(" ", arrW));
                //Console.WriteLine(W);
                //Console.WriteLine(n);
                _maxValue = new int[n + 2, W + 1];
                MaxValue(W, arrW);
                Console.WriteLine(_maxValue[n, W]);
                //Console.ReadLine();
            //}
        }

        static void MaxValue(int w, int[] arrW)
        {
            for (int k = 0; k < arrW.Length; k++)
            {
                for (int i = 1; i <= w; i++)
                {
                    _maxValue[k + 1, i] = _maxValue[k, i];
                    if (arrW[k] > i)
                        continue;
                    var newPossibleValue = _maxValue[k, i - arrW[k]] + arrW[k];
                    if (newPossibleValue <= i && newPossibleValue > _maxValue[k, i])
                        _maxValue[k + 1, i] = newPossibleValue;
                }
            }
        }

        static int[] GetRandomisedSortedArray(int n, int maxN, Random rnd)
        {
            var res = new int[n];
            for(int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    res[i] = rnd.Next(0, maxN - n + i);
                }
                else
                {
                    res[i] = rnd.Next(res[i - 1] + 1, maxN - n + i);
                }
            }

            return res;
        }
    }
}

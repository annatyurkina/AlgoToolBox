using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsOfGold
{
    class Program
    {
        private static int[] _maxValue;
        static void Main(string[] args)
        {
            while (true)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] arrW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int W = arr[0];
                int n = arr[1];
                _maxValue = new int[W + 1];
                MaxValue(W, arrW);
                Console.Write(_maxValue[W]);
            }
        }

        static void MaxValue(int w, int[] arrW)
        {
            for (int i = 1; i <= w; i++)
            {
                int maxV = 0;
                for (int j = 0; j < arrW.Length; j++)
                {
                    if(arrW[j] > i)
                        continue;
                    if (arrW[j] == i)
                    {
                        maxV = i;
                    }
                    else
                    {
                        var newW = _maxValue[i - arrW[j]] + arrW[j];
                        if (newW <= w)
                        {
                            if (newW > maxV)
                            {
                                maxV = newW;
                            }
                        }
                    } 
                }
                _maxValue[i] = maxV;
            }
        }
    }
}

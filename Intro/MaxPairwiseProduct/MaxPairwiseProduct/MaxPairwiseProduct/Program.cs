using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPairwiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 n = Int64.Parse(Console.ReadLine());
            Int64[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
            //var rnd = new Random(23);
            //Int64 n = rnd.Next(0, 1000) % 1000 + 2;// Int64.Parse(Console.ReadLine());
            //Int64[] arr = new Int64[n];// Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = rnd.Next(0, 10000);
            //}
            //while(true)
            //{
            //    if(FindMaxPairwiseProduct(arr) != FindMaxPairwiseProductFast(arr))
            //    {
            //        Console.WriteLine(n);
            //        Console.WriteLine(string.Join(" ", arr));
            //        Console.WriteLine(FindMaxPairwiseProduct(arr) + " " + FindMaxPairwiseProductFast(arr));
            //        break;
            //    }
            //    Console.WriteLine("OK");
            //}
            Console.WriteLine(FindMaxPairwiseProductFast(arr));
            Console.ReadLine();
        }

        static Int64 FindMaxPairwiseProduct(Int64[] arr)
        {
            Int64 maxProduct = 0;
            for (Int64 i = 0; i < arr.Length; i++)
            {
                for(Int64 j = 0; j < arr.Length; j++)
                {
                    if(i != j && maxProduct < arr[i]*arr[j])
                    {
                        maxProduct = arr[i] * arr[j];
                    }
                }
            }
            return maxProduct;
        }

        static Int64 FindMaxPairwiseProductFast(Int64[] arr)
        {
            Int64 maxIndex1 = 0;
            Int64 maxIndex2 = 0;
            for (Int64 i = 0; i < arr.Length; i++)
            {
                if(maxIndex1 == 0 || arr[i] > arr[maxIndex2] && i != maxIndex2)
                {
                    if (maxIndex2 == 0 || arr[i] > arr[maxIndex1] && i != maxIndex1)
                    {
                        maxIndex2 = maxIndex1;
                        maxIndex1 = i;
                    }
                    else
                    {
                        maxIndex2 = i;
                    }
                }
            }
            return arr[maxIndex1] * arr[maxIndex2];
        }
    }
}

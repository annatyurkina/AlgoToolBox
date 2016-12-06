using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //while (true)
            //{
            //    var rnd = new Random();
            //    var n = rnd.Next(1, 10000);
            //    int[] arr = new int[n + 1];
            //    arr[0] = n;
            //    for (int i = 1; i <= n; i++)
            //    {
            //        arr[i] = rnd.Next(1, 1000000000);
            //    }
            //    var k = rnd.Next(1, 10000);
            //    int[] inputArr = new int[k + 1];
            //    inputArr[0] = k;
            //    for (int i = 1; i <= k; i++)
            //    {
            //        inputArr[i] = rnd.Next(1, 1000000000);
            //    }

            for (int i = 1; i <= inputArr[0]; i++)
            {
                    Console.Write(BinarySearchIter(arr, inputArr[i], 1, arr[0]) - 1);
                    if (i <= inputArr[0] - 1)
                        Console.Write(" ");
            }
            //Console.WriteLine();
            //for (int i = 1; i <= inputArr[0]; i++)
            //{
            //    Console.Write(LinearSearch(arr, inputArr[i]));
            //    if (i <= inputArr[0] - 1)
            //        Console.Write(" ");
            //}
            //}
            //Console.ReadLine();
        }

        static int BinarySearch(int[] arr, int k, int start, int end)
        {
            if (start == end)
                return k == arr[start] ? start : 0;

            var index = (int)Math.Ceiling(((long)start + (long)end) / 2.0);

            if (k == arr[index])
                return index;
            if (k > arr[index])
                return BinarySearch(arr, k, index + 1, end);
            return BinarySearch(arr, k, start, index - 1);
        }

        static int BinarySearchIter(int[] arr, int k, int start, int end)
        {
            while (start < end)
            {
                var index = (int)Math.Ceiling(((long)start + (long)end) / 2.0);

                if (k == arr[index])
                    return index;
                if (k > arr[index])
                    start = Math.Min(index + 1, end);
                else
                    end = Math.Max(index - 1, start);
            }
            return k == arr[start] ? start : 0;
        }

        static int LinearSearch(int[] arr, int k)
        {
            return arr.Skip(1).ToArray().ToList().IndexOf(k);
        }
    }
}

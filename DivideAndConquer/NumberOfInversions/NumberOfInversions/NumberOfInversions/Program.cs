using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //var rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            //while (true)
            //{
            //    int n = rnd.Next(1, 10000);
            //    int[] arr = new int[n];
            //    for (int i = 0; i < n; i++)
            //    {
            //        arr[i] = rnd.Next(1, 1000000000);
            //    }

            //    int[] testarr = new int[arr.Length];
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        testarr[i] = arr[i];
            //    }

                long numberOfInversions = MergeSort(arr, 0, n - 1);
                //int numberOfInversionsNaive = NaiveNumberOfInversions(testarr);

            //    if(numberOfInversions != numberOfInversionsNaive)
            //    {
            //        Console.WriteLine("ERROR");
            //        Console.WriteLine(string.Join(" ", arr));
            //        Console.WriteLine(string.Join(" ", testarr));
            //        Console.WriteLine(numberOfInversions);
            //        Console.WriteLine(numberOfInversionsNaive);
            //        break;
            //    }
            //    Console.WriteLine("good");

            //}

            Console.WriteLine(numberOfInversions);
            //Console.WriteLine(numberOfInversionsNaive);
            //Console.WriteLine(string.Join(" ", arr));
            //Console.WriteLine(string.Join(" ", testarr));
            //Console.ReadLine();
        }

        static long MergeSort(int[] arr, int left, int right)
        {
            long numberOfInversions = 0;

            if (left >= right)
                return numberOfInversions;

            numberOfInversions += MergeSort(arr, left, (int)Math.Floor((right + left) / 2.0));
            numberOfInversions += MergeSort(arr, (int)Math.Floor((right + left) / 2.0) + 1, right);
            numberOfInversions += Merge(arr, left, (int)Math.Floor((right + left) / 2.0), right);

            return numberOfInversions;
        }

        static long Merge(int[] arr, int left, int middle, int right)
        {
            long numberOfInversions = 0;
            int[] leftSubArray = new int[middle - left + 1];
            int[] rightSubArray = new int[right - middle];

            for(int i = 0; i<= right - left; i++)
            {
                if(i <= middle - left)
                {
                    leftSubArray[i] = arr[i + left];
                }
                else
                {
                    rightSubArray[i - middle + left - 1] = arr[i + left];
                }
            }

            int leftInd = 0;
            int rightInd = 0;
            for(int i = left; i <=right; i++)
            {
                if (leftInd + left > middle)
                {
                    arr[i] = rightSubArray[rightInd];
                    rightInd++;
                    continue;
                }
                else if (rightInd + middle + 1 > right)
                {
                    arr[i] = leftSubArray[leftInd];
                    leftInd++;
                    continue;
                }
                else if (leftSubArray[leftInd] <= rightSubArray[rightInd])
                {
                    arr[i] = leftSubArray[leftInd];
                    leftInd++;
                }
                else
                {
                    arr[i] = rightSubArray[rightInd];
                    numberOfInversions += middle - left - leftInd + 1;
                    rightInd++;
                }
            }

            return numberOfInversions;
        }

        static int NaiveNumberOfInversions(int[] testarr)
        {
            int numberOfInversions = 0;
            for(int i = 0; i < testarr.Length; i++)
            {
                for(int j = i + 1; j < testarr.Length; j++)
                {
                    if (testarr[i] > testarr[j])
                        numberOfInversions++;
                }
            }

            return numberOfInversions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort3
{
    class Program
    {
        private static Random _rnd = new Random();
         
        static int Partition2(int[] arr, int left, int right)
        {
            int x = arr[left];
            int j = left;

            for (int i = left + 1; i <= right; i++)
            {
                if (arr[i] <= x)
                {
                    j++;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            var temp1 = arr[left];
            arr[left] = arr[j];
            arr[j] = temp1;
            return j;
        }

        static int[] Partition3(int[] arr, int left, int right)
        {
            int x = arr[left];
            int j = left;
            int k = left;

            for (int i = left + 1; i <= right; i++)
            {
                if (arr[i] < x)
                {
                    k++;
                    var temp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = temp;
                    temp = arr[k];
                    arr[k] = arr[j];
                    arr[j] = temp;
                    j++;
                }
                else if(arr[i] == x)
                {
                    k++;
                    var temp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = temp;
                }
            }
            return new int[2] { j, k};
        }

        static void RandomizedQuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int k = left + _rnd.Next(0, right - left + 1);
            var temp1 = arr[left];
            arr[left] = arr[k];
            arr[k] = temp1;
            int[] m = Partition3(arr, left, right);

            RandomizedQuickSort(arr, left, m[0] - 1);
            RandomizedQuickSort(arr, m[1] + 1, right);
        }

        static void Main()
        {
            //while (true)
            //{
                int n = int.Parse(Console.ReadLine());
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                //int n = _rnd.Next(1, 10000);
                //int[] arr = new int[n];
                //for (int i = 0; i < n; i++)
                //{
                //    arr[i] = _rnd.Next(1, 1000000000);
                //}
                //Console.WriteLine(string.Join(" ", arr));
                //int[] testarr = arr;

                RandomizedQuickSort(arr, 0, arr.Length - 1);
                //Array.Sort(testarr);



                for (int i = 0; i < arr.Length; i++)
                {
                    //if (arr[i] != testarr[i])
                    //{
                    //    throw new ApplicationException("ERROR: " + string.Join(" ", arr) + Environment.NewLine + string.Join(" ", testarr));
                    //}
                    Console.Write(arr[i] + " ");
                }
            //}
            //Console.ReadLine();
        }

    }
}

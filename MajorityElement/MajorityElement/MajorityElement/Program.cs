using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine(MajorityElement(arr, 0, n - 1) == -1 ? 0 : 1 );
            //Console.ReadLine();
        }

        static int MajorityElement(int[] arr, int left, int right)
        {
            if (left == right)
                return arr[left];
            int k = (int)Math.Floor((right + left) / 2.0);
            var leftMaj = MajorityElement(arr, left, k);
            var rightMaj = MajorityElement(arr, k + 1, right);
            if (leftMaj == rightMaj)
                return leftMaj;
            var lcount = GetFrequency(arr, left, right, leftMaj);
            var rcount = GetFrequency(arr, left, right, rightMaj);
            if (lcount > (int)Math.Floor((right - left + 1) / 2.0))
                return leftMaj;
            else if (rcount > (int)Math.Floor((right - left + 1) / 2.0))
                return rightMaj;
            else return -1;
        }

        static int GetFrequency(int[] arr, int left, int right, int n)
        {
            var res = 0;
            for(int i = left; i <= right; i++)
            {
                if (arr[i] == n)
                    res++;
            }
            return res;
        }
    }
}

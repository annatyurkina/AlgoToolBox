using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximisingSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                var rnd = new Random();
                int n = //rnd.Next(1, 100);
                int.Parse(Console.ReadLine());
                int[] nums = //new int[n];
                    Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                //for(int i = 0; i < n; i++)
                //{
                //    nums[i] = rnd.Next(1, 1000);
                //}

                //Console.WriteLine(SecretFunc(nums[0], nums[1]));
                Console.WriteLine(GetSalaryString(n, nums));
            //}
            //Console.ReadLine();
        }

        static string GetSalaryString(int n, int[] nums)
        {
            string res = string.Empty;

            for (int i=0; i < n; i++)
            {
                int maxDigit = 0;
                int index = -1;
                for (int j=0; j < n; j++)
                {
                    if (SecretFunc(nums[j], maxDigit))
                    {
                        maxDigit = nums[j];
                        index = j;
                    }
                }
                res = res + maxDigit;
                nums[index] = 0;
            }

            return res;
        }

        static bool SecretFunc(int n, int m)
        {
            int numberOfDigitsN = n == 0 ? 1 : (int)Math.Floor(Math.Log10(n) + 1);
            int numberOfDigitsM = m == 0 ? 1 : (int)Math.Floor(Math.Log10(m) + 1);
            return (n * Math.Pow(10, numberOfDigitsM) + m) > (m * Math.Pow(10, numberOfDigitsN) + n);
        }
    }
}

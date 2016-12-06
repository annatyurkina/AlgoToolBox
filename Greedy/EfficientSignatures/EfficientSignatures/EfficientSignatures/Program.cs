using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfficientSignatures
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
                int[] leftLimits = new int[n];
                int[] rightLimits = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int[] intervalLimits = //new int[2] { rnd.Next(0, 1000000000), rnd.Next(0, 1000000000) };
                        Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    leftLimits[i] = intervalLimits[0];
                    rightLimits[i] = intervalLimits[1];
                }
                Console.WriteLine(GetCoveragePoints(n, leftLimits, rightLimits));
            //}
            //Console.ReadLine();
        }

        static string GetCoveragePoints(int n, int[] leftLimits, int[] rightLimits)
        {
            Array.Sort(rightLimits, leftLimits);
            List<int> points = new List<int>();
            points.Add(rightLimits[0]);

            for(int i = 1; i < n; i++)
            {
                if(leftLimits[i] > points.Last())
                {
                    points.Add(rightLimits[i]);
                }
            }

            return points.Count + Environment.NewLine + string.Join(" ", points);
        }
    }
}

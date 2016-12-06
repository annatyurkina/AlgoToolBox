using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] m = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] intervalsLeft = new int[m[0]];
            int[] intervalsRight = new int[m[0]];
            for (int i = 0; i < m[0]; i++)
            {
                int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                intervalsLeft[i] = temp[0];
                intervalsRight[i] = temp[1];
            }
            int[] points = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine(string.Join(" ", DoIt(intervalsLeft, intervalsRight, points)));
            //Console.ReadLine();
            //while (true)
            //{
            //    int maxNum = 500; //50000;
            //    int minPoint = -1000; //-100000000;
            //    int maxPoint = 1000;// 100000000;
            //    var rnd = new Random();
            //    int pointsNum = rnd.Next(1, maxNum);
            //    int[] points = new int[pointsNum];
            //    for (int i = 0; i < pointsNum; i++)
            //    {
            //        points[i] = rnd.Next(minPoint, maxPoint);
            //    }

            //    int intervalsNum = rnd.Next(1, maxNum);
            //    int[] intervalsLeft = new int[intervalsNum];
            //    int[] intervalsRight = new int[intervalsNum];
            //    for (int i = 0; i < intervalsNum; i++)
            //    {
            //        intervalsLeft[i] = rnd.Next(minPoint, maxPoint);
            //        intervalsRight[i] = rnd.Next(minPoint, maxPoint);
            //    }
            //    if(string.Join(" ", DoIt(intervalsLeft, intervalsRight, points)) != string.Join(" ", DoItNaive(intervalsLeft, intervalsRight, points)))
            //        {
            //        Console.WriteLine("ERROR " + DoIt(intervalsLeft, intervalsRight, points) + "vs" + DoItNaive(intervalsLeft, intervalsRight, points));

            //    }
            //    Console.WriteLine(string.Join(" ", DoIt(intervalsLeft, intervalsRight, points)));
            //    Console.WriteLine();
            //}
        }

        static int[] DoIt(int[] intLeft, int[] intRight, int[] points)
        {
            var res = new int[points.Length];
            
            Array.Sort(intLeft, intRight);

            for (int j = 0; j < points.Length; j++) 
            {
                for (int i = 0; i < intLeft.Length; i++)
                {
                    if (points[j] >= intLeft[i])
                    {
                        if (points[j] <= intRight[i])
                            res[j]++;
                    }
                    else break;
                }
            }

            return res;
        }

        static int[] DoItNaive(int[] intLeft, int[] intRight, int[] points)
        {
            var res = new int[points.Length];

            for (int i = 0; i < intLeft.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (points[j] >= intLeft[i])
                    {
                        if (points[j] <= intRight[i])
                            res[j]++;
                    }
                }
            }

            return res;
        }
    }
}

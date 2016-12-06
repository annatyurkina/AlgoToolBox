using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                var rnd = new Random();
                int[] totals = //new int[2] { rnd.Next(1, 1000), rnd.Next(0, 2000000) };
                Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                SortedList<double, int> items = new SortedList<double, int>();

                for (int i = 0; i < totals[0]; i++)
                {
                    int[] item = //new int[2] { rnd.Next(0, 2000000), rnd.Next(1, 2000000) };
                    Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    double valuePerUnit = (double)item[0] / (double)item[1];
                    if (items.ContainsKey(valuePerUnit))
                    {
                        items[valuePerUnit] += item[1];
                    }
                    else
                    {
                        items.Add(valuePerUnit, item[1]);
                    }
                }

                Console.WriteLine(GetMaximisedValue(items, totals[1]));
            //}
            Console.ReadLine();
        }

        static double GetMaximisedValue(SortedList<double, int> items, int totalWeight)
        {
            double value = 0.0;
            foreach(var item in items.Reverse())
            {
                if(totalWeight <= item.Value)
                {
                    value += item.Key * (double)totalWeight;
                    break;
                }
                value += item.Key * (double)item.Value;
                totalWeight -= item.Value;
            }
            return Math.Round(value, 4); ;
        }
    }
}

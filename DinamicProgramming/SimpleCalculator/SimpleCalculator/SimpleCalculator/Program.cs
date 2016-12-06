using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static int[] _minCalcs;
        static int[] _prevNums;

        static void Main(string[] args)
        {
            //var rnd = new Random();
            //while (true)
            //{
            var n = //rnd.Next(1, 1000000); //
                int.Parse(Console.ReadLine());
            _minCalcs = new int[n + 1];
            _prevNums = new int[n + 1];
            MinCalcs(n);
            Console.WriteLine(_minCalcs[n]);
            Console.WriteLine(string.Join(" ", ProcessPrevNum(n)));
            //Console.ReadLine();
            //}
        }

        static void MinCalcs(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                var minNum = int.MaxValue;
                if (i == 1)
                {
                    _minCalcs[1] = 0;
                    continue;
                }
                if (i % 3 == 0 && (i / 3 == 1 || _minCalcs[i / 3] != 0))
                {
                    if (_minCalcs[i / 3] + 1 < minNum)
                    {
                        minNum = _minCalcs[i / 3] + 1;
                        _prevNums[i] = i / 3;
                    }
                }
                if (i % 2 == 0 && (i / 2 == 1 || _minCalcs[i / 2] != 0))
                {
                    if (_minCalcs[i / 2] + 1 < minNum)
                    {
                        minNum = _minCalcs[i / 2] + 1;
                        _prevNums[i] = i / 2;
                    }
                }
                if (i - 1 == 1 || _minCalcs[i - 1] != 0)
                {
                    if (_minCalcs[i - 1] + 1 < minNum)
                    {
                        minNum = _minCalcs[i - 1] + 1;
                        _prevNums[i] = i - 1;
                    }
                }
                _minCalcs[i] = minNum;
            }
        }

        static List<int> ProcessPrevNum(int n)
        {
            List<int> res = new List<int>();
            res.Add(n);
            var current = n;

            while (current > 1)
            {
                current = _prevNums[current];
                res.Add(current);
            }
            res.Reverse();
            return res;
        }
    }
}

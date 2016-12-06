using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticalExpression
{
    class Program
    {
        static long[,] _max;
        static long[,] _min;
        static char[] _expression;

        static void Main(string[] args)
        {
            //while (true)
            //{
                //_expression = GetRandomExpression();// Console.ReadLine().ToCharArray();
                _expression = Console.ReadLine().ToCharArray();
                //Console.WriteLine(string.Join(" ", _expression));
                int n = (int)Math.Ceiling(((double)_expression.Length) / 2.0);
                _max = new long[n, n];
                _min = new long[n, n];

                Parentheses(n);
                Console.WriteLine(_max[0, n - 1]);
                //Console.WriteLine(_max[0, 0]);
                //Console.WriteLine(_max[1, 0]);
                //Console.WriteLine(_max[0, 1]);
                //Console.WriteLine(_max[1, 1]);
                //Console.ReadLine();
            //}
        }

        static void Parentheses(int n)
        {
            for(int i = 0; i< n; i++)
            {
                _max[i, i] = int.Parse(_expression[2 * i].ToString());
                _min[i, i] = int.Parse(_expression[2 * i].ToString());
            }
            for(int s = 1; s <= n - 1; s++)
            {
                for(int i = 0; i < n - s; i++)
                {
                    var j = i + s;
                    MinAndMax(i, j);
                }
            }

        } 

        static void MinAndMax(int i, int j)
        {
            _min[i, j] = int.MaxValue;
            _max[i, j] = int.MinValue;

            for(int k = i; k < j; k++)
            {
                CheckOp(k, _max[i, k], _max[k + 1, j], i, j);
                CheckOp(k, _max[i, k], _min[k + 1, j], i, j);
                CheckOp(k, _min[i, k], _max[k + 1, j], i, j);
                CheckOp(k, _min[i, k], _min[k + 1, j], i, j);
            }
        }


        static long Op(int k, long a, long b)
        {
            char op = _expression[2 * k + 1];
            if (op == '+')
                return a + b;
            if (op == '-')
                return a - b;
            if (op == '*')
                return a * b;
            throw new Exception("WTF is " + op);
        }

        static void CheckOp(int k, long a, long b, int i, int j)
        {
            var aOpB = Op(k, a, b);
            if (aOpB < _min[i, j])
                _min[i, j] = aOpB;
            if (aOpB > _max[i, j])
                _max[i, j] = aOpB;
        }


        static char[] GetRandomExpression()
        {
            var rnd = new Random();
            var n = rnd.Next(1, 14);
            n = 2 * n + 1;
            var res = new char[n];
            for (int i = 0; i < n; i++)
            {
                if(i%2 == 0)
                {
                    res[i] = rnd.Next(0, 9).ToString()[0]; 
                }
                else
                {
                    res[i] = GetOp(rnd.Next(1, 3));
                }
            }

            return res;
        }


        static char GetOp(int n)
        {
            if (n == 1)
                return '+';
            if (n == 2)
                return '-';
            return '*';
        }


    }
}

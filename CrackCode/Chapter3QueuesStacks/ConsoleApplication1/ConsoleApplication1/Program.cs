using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyStack ms = new MyStack(10);
            ms.Push(10);
            Console.WriteLine(ms.Min());
            ms.Push(20);
            Console.WriteLine(ms.Min());
            ms.Push(5);
            Console.WriteLine(ms.Min());
            ms.Pop();
            Console.WriteLine(ms.Min());
            ms.Pop();
            Console.WriteLine(ms.Min());
            ms.Pop();
            Console.ReadLine();
        }

        public class MyStack
        {
	        private Node[] s;
            private int lastIndex;

            public MyStack(int n)
            {
                s = new Node[n];
                lastIndex = -1;
            }

            public void Push(int m)
            {
                Node newEl = new Node() { Value = m };
                int curMinIndex = lastIndex != -1 ? s[lastIndex].Min : -1;
                int curMinValue = curMinIndex != -1 ? s[curMinIndex].Value : int.MaxValue;
                newEl.Min = curMinValue > newEl.Value ? lastIndex + 1 : curMinIndex;
                lastIndex++;
                s[lastIndex] = newEl;
            }

            public int Pop()
            {
                if (IsEmpty())
                    throw new Exception("Empty Stack");
                lastIndex--;
                return (s[lastIndex + 1].Value);
            }

            public bool IsEmpty()
            {
                return lastIndex == -1;
            }

            public int Peek()
            {
                if (IsEmpty())
                    throw new Exception("Empty Stack");
                return s[lastIndex].Value;
            }

            public int Min()
            {
                if (IsEmpty())
                    throw new Exception("Empty Stack");
                return s[s[lastIndex].Min].Value;
            }
        }

        public class Node
        {
	        public int Value { get; set; }
            public int Min { get; set; }
        }
    }
}

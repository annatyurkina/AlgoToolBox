using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        public static void Main(string[] args)
        {
            AssertEquals(RemoveDups(null), null);
            LinkedList testList = new LinkedList(null, null);
            AssertEquals(RemoveDups(testList), testList);
            Node testNode = new Node(3, null);
            testList = new LinkedList(testNode, testNode);
            AssertEquals(RemoveDups(testList), testList);
            AssertEquals(RemoveDups(new LinkedList(new int[2] { 3, 2 })), new LinkedList(new int[2] { 3, 2 }));
            AssertEquals(RemoveDups(new LinkedList(new int[2] { 3, 3 })), new LinkedList(new int[1] { 3 }));
            AssertEquals(RemoveDups(new LinkedList(new int[3] { 3, 2, 3 })), new LinkedList(new int[2] { 3, 2 }));
            AssertEquals(RemoveDups(new LinkedList(new int[3] { 3, 3, 3 })), new LinkedList(new int[1] { 3 }));
            AssertEquals(RemoveDups(new LinkedList(new int[4] { 1, 2, 3, 1 })), new LinkedList(new int[3] { 1, 2, 3 }));
            AssertEquals(RemoveDups(new LinkedList(new int[4] { 1, 2, 2, 3 })), new LinkedList(new int[3] { 1, 2, 3 }));

            Console.WriteLine("Success");
            Console.ReadLine();
        }

        public static void AssertEquals(object a, object b)
        {
            if (a == null)
            {
                if (b == null)
                    return;
                throw new Exception(string.Format("Expected null, got {0}", b));
            }
            if (!a.Equals(b))
                throw new Exception(string.Format("Expected {0}, got {1}", b, a));
        }


        public class LinkedList
        {
            public Node First { get; set; }
            public Node Last { get; set; }

            public LinkedList(Node first, Node last)
            {
                First = first;
                Last = last;
            }

            public void AppendToEnd(int data)
            {
                if (First == null)
                {
                    First = new Node(data, null);
                    Last = First;
                }
                else
                {
                    Node newLast = new Node(data, null);
                    Last.Next = newLast;
                    Last = newLast;
                }
            }

            public LinkedList(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    AppendToEnd(arr[i]);
                }
            }

            public override string ToString()
            {
                StringBuilder res = new StringBuilder();
                Node current = First;
                while (current != null)
                {
                    res.Append(current.Data);
                    current = current.Next;
                }
                return res.ToString();
            }

            public override bool Equals(object list)
            {
                if(!(list is LinkedList))
                    return false;
                if (First == null || ((LinkedList)list).First == null)
                    return First == null && Last == null && ((LinkedList)list).First == null && ((LinkedList)list).Last == null;
                Node currThis = First;
                Node currList = ((LinkedList)list).First;

                while (currThis != null && currList != null)
		        {
                    if (currThis.Data != currList.Data)
                        return false;
                    currThis = currThis.Next;
                    currList = currList.Next;
                }
                return currThis == null && currList == null;
            }
        }

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }


        public static LinkedList RemoveDups(LinkedList list)
        {
            if (list == null || list.First == null || list.First == list.Last)
                return list;
            Node nodeToCheck = list.First;
            Node prev = null;

            while (nodeToCheck != null)
            {
                bool isDup = false;
                Node current = list.First;
                while (current != nodeToCheck)
                {
                    if (current.Data == nodeToCheck.Data)
                    {
                        prev.Next = nodeToCheck.Next;
                        nodeToCheck = nodeToCheck.Next;
                        isDup = true;
                        break;
                    }
                    current = current.Next;
                }
                if (!isDup)
                {
                    nodeToCheck = nodeToCheck.Next;
                    prev = prev == null ? list.First : prev.Next;
                }
            }
            list.Last = prev;

            return list;
        }
    }
}

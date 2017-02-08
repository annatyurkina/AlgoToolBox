using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int[] _hashes;

        static void Main(string[] args)
        {
            char[] pattern = Console.ReadLine().ToCharArray();
            char[] text = Console.ReadLine().ToCharArray();
            _hashes = new int[text.Length - pattern.Length + 1];

            FillInHashes(text, pattern.Length);

            List<int> res = FindPattern(text, pattern);
            Console.WriteLine(string.Join(" ", res));
            Console.ReadLine();

        }

        static int Hash(char[] text, int start, int end)
        {
            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            int p = 500009;
            int x = 5;
            int m = 1000;
            int curr = 0;

            for (int i = end; i >= start; i--)
            {
                curr = curr * x % p + textBytes[i];
            }

            return curr % p;
        }

        static void FillInHashes(char[] text, int pl)
        {
            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            int p = 500009;
            int x = 5;
            int m = 1000;
            int curr = 0;
            _hashes[text.Length - pl] = Hash(text, text.Length - pl, text.Length - 1);
            int xPow = HashedPow(x, pl, p);

            for (int i = text.Length - pl - 1; i >= 0; i--)
            {
                _hashes[i] = (_hashes[i + 1] * x % p + textBytes[i] + (p + (-1) * xPow * textBytes[i + pl] % p) %p) % p;
            }

        }


        static int HashedPow(int x, int y, int p)
        {
            int res = 1;
            for (int i = 0; i < y; i++)
            {
                res = res * x % p;
            }
            return res;
        }

        static List<int> FindPattern(char[] text, char[] pattern)
        {
            List<int> res = new List<int>();
            int patternHash = Hash(pattern, 0, pattern.Length - 1);

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if(patternHash == _hashes[i] && AreEqual(pattern, text, i, i + pattern.Length - 1))
                    res.Add(i);
            }
            return res;
        }

        static bool AreEqual(char[] s1, char[] s2, int start, int end)
        {
            if (s1.Length != end - start + 1)
                return false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[start + i])
                    return false;
            }
            return true;
        }
    }
}

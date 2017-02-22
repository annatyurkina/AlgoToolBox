using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (!AllCharactersAreUnique(null))
                throw new ApplicationException("null - all chars unique");
            if(!AllCharactersAreUnique(string.Empty))
                throw new ApplicationException("empty - all chars unique");
            if(!AllCharactersAreUnique("abcd"))
                throw new ApplicationException("abcd - all chars unique");
            if(AllCharactersAreUnique("aaaabbbb"))
                throw new ApplicationException("aaaabbbb not all chars unique");
            if(AllCharactersAreUnique("danlkman"))
                throw new ApplicationException("danlkman - not all chars unique");
            if (Reverse(null) != null)
		        throw new Exception("null should reverse to null");
            if (Reverse(string.Empty) != string.Empty)
                throw new Exception("expect string.Empty");
            if (Reverse("a") != "a")
                throw new Exception("expect a");
            if (Reverse("ab") != "ba")
                throw new Exception("expected ba");
            if (Reverse("abcd") != "dcba")
                throw new Exception("expected dcba");
            if (Reverse("abcde") != "edcba")
                throw new Exception("expected edcba");
            if (RemoveDuplicateChars(null) != null)
                throw new ApplicationException("null - all chars unique");
            if (RemoveDuplicateChars(string.Empty) != string.Empty)
                throw new ApplicationException("empty - all chars unique");
            if (RemoveDuplicateChars("abcd") != "abcd")
                throw new ApplicationException("abcd - all chars unique");
            if (RemoveDuplicateChars("aaaabbbb") != "ab")
                throw new ApplicationException("aaaabbbb not all chars unique");
            if (RemoveDuplicateChars("danlkman") != "danlkm")
                throw new ApplicationException("danlkman - not all chars unique");
            if (RemoveDupChars(null) != null)
                throw new ApplicationException("null - all chars unique");
            if (RemoveDupChars(string.Empty) != string.Empty)
                throw new ApplicationException("empty - all chars unique");
            if (RemoveDupChars("abcd") != "abcd")
                throw new ApplicationException("abcd - all chars unique");
            if (RemoveDupChars("aaaabbbb") != "ab")
                throw new ApplicationException("aaaabbbb not all chars unique");
            if (RemoveDupChars("danlkman") != "danlkm")
                throw new ApplicationException("danlkman - not all chars unique");
            if (IsAnagram(null, "sss"))
                throw new ApplicationException();
            if (IsAnagram("sss", null))
                throw new ApplicationException();
            if (IsAnagram("", "sss"))
                throw new ApplicationException();
            if (IsAnagram("sss", ""))
                throw new ApplicationException();
            if (IsAnagram("sasa", "asasa"))
                throw new ApplicationException();
            if (IsAnagram("abakn", "baka"))
                throw new ApplicationException();
            if (IsAnagram("brown brow", "brow brown") == false)
                throw new ApplicationException();
            if (IsAnagram("zanoza", "nozzaa") == false)
                throw new ApplicationException();
            if (IsAnagram("krakozyabra", "krakozrabra"))
                throw new ApplicationException();
            if (InsertSubstring(null, "%20", ' ') != null)
                throw new Exception();
            if (InsertSubstring("", "%20", ' ') != string.Empty)
                throw new Exception();
            if (InsertSubstring("abcd", "%20", ' ') != "abcd")
                throw new Exception();
            if (InsertSubstring("ab cd", "%20", ' ') != "ab%20cd")
                throw new Exception();
            if (InsertSubstring("   bb b   ", "%20", ' ') != "%20%20%20bb%20b%20%20%20")
                throw new Exception();
            if (!IsRotation(null, null))
                throw new Exception();
            if (!IsRotation(string.Empty, string.Empty))
                throw new Exception();
            if (IsRotation(null, "sss"))
                throw new Exception();
            if (IsRotation("sss", string.Empty))
                throw new Exception();
            if (IsRotation("sss", "sas"))
                throw new Exception();
            if (IsRotation("sss", "ssss"))
                throw new Exception();
            if (!IsRotation("sas", "ass"))
                throw new Exception();
            if (!IsRotation("karamba", "akaramb"))
                throw new Exception();
            if (!IsRotation("slice", "icesl"))
                throw new Exception();
            if (Rotate90(new int[,] { }).GetLength(0) != 0)
                throw new Exception();
            if (Rotate90(new int[,] {{5}}).GetLength(0) != 1)
                throw new Exception();
            Print2DArray(new int[,] { { 1, 2 }, { 3, 4 } });
            Print2DArray(Rotate90(new int[,] { { 1, 2 },{ 3, 4 } }));
            Print2DArray(Rotate90(new int[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}));
            Print2DArray(Rotate90(new int[,] {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14 , 15, 16} }));
            Print2DArray(ZeroRowsCols(new int[,] {{0, 2}, {3, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] {{1, 0}, {3, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] {{1, 2}, {0, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] {{1, 2}, {3, 0}}));
            Print2DArray(ZeroRowsCols(new int[,] {{0, 2}, {3, 0}}));
            Print2DArray(ZeroRowsCols(new int[,] {{0, 0}, {3, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] {{0, 2}, {0, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] {{1, 2}, {3, 4}}));
            Print2DArray(ZeroRowsCols(new int[,] { { 1, 0, 3 },{ 3, 4, 5 }, { 6, 0, 8 } }));

            Console.ReadLine();
        }

        public static void Print2DArray(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", arr[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }

        public static bool AllCharactersAreUnique(string str)
        {
            if (str == null || str.Length <= 1)
                return true;
            int[] arr = Array.ConvertAll(str.ToCharArray(), Convert.ToInt32);
            bool[] flags = new bool[256];
            for (int i = 0; i < arr.Length; i++)
            {
                if (flags[arr[i]])
                    return false;
                flags[arr[i]] = true;
            }
            return true;
        }

        public static string Reverse(string str)
        {
            if (str == null || str.Length <= 1)
                return str;
            char[] chars = str.ToCharArray();
            char temp;
            for (int i = 0; i <= chars.Length / 2 - 1; i++)
            {
                temp = chars[i];
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = temp;
            }
            var res = new string(chars);
            return res;
        }

        public static string RemoveDuplicateChars(string str)
        {
            if (str == null || str.Length == 0)
                return str;
            char[] chars = str.ToCharArray();
            int length = chars.Length;
            for (int i = 0; i < length - 1; i++)
            {
                bool isUnique = true;
                for (int j = 0; j <= length; j++)
                {
                    if (j < i + 1)
                    {
                        if (chars[j] == chars[i + 1])
                        {
                            isUnique = false;
                            length--;
                            j = i + 1;
                        }
                    }
                    if (j >= i + 1 && j < chars.Length - 1)
                    {
                        if (!isUnique)
                        {
                            chars[j] = chars[j + 1];
                        }
                        else
                            break;
                    }
                }
                if (!isUnique)
                    i--;
            }
            var res = new string(chars.Take(length).ToArray());
            return res;
        }

        public static string RemoveDupChars(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            bool[] letters = new bool[256];
            char[] chars = str.ToCharArray();
            int gaps = 0;
            for (int i = 0; i < chars.Length - gaps; i++)
            {
                if (!letters[chars[i]])
                {
                    letters[chars[i]] = true;
                }
                else
                {
                    gaps++;
                    if (i + gaps < chars.Length)
                    {
                        chars[i] = chars[i + gaps];
                        i--;
                    }
                }
            }
            return new string(chars.Take(chars.Length - gaps).ToArray());
        }

        public static bool IsAnagram(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
                return false;
            char[] chars1 = str1.ToArray();
            char[] chars2 = str2.ToArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < chars1.Length; i++)
            {
                if (dict.ContainsKey(chars1[i]))
                {
                    dict[chars1[i]]++;
                }
                else
                {
                    dict.Add(chars1[i], 1);
                }
            }
            for (int i = 0; i < chars1.Length; i++)
            {
                if (dict.ContainsKey(chars2[i]))
                {
                    if (dict[chars2[i]] > 1)
                    {
                        dict[chars2[i]]--;
                    }
                    else
                    {
                        dict.Remove(chars2[i]);
                    }
                }
                else
                {
                    return false;
                }
            }
            return dict.Count == 0;
        }

        public static string InsertSubstring(string str, string sub, char toReplace)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            char[] arr = str.ToCharArray();
            char[] subArr = sub.ToCharArray();
            int toReplaceCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == toReplace)
                    toReplaceCount++;
            }
            char[] res = new char[arr.Length + toReplaceCount * (subArr.Length - 1)];
            for (int i = 0, j = 0; i < arr.Length && j < res.Length; i++, j++)
            {
                if (arr[i] != toReplace)
                {
                    res[j] = arr[i];
                }
                else
                {
                    for (int k = 0; k < subArr.Length; k++)
                    {
                        res[j] = subArr[k];
                        j++;
                    }
                    j--;
                }
            }
            return new string(res);
        }

        public static bool IsRotation(string str1, string str2)
        {
            if (str1 == str2)
                return true;
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
                return false;
            return (str2 + str2).Contains(str1);
        }

        public static int[,] Rotate90(int[,] img)
        {
            int N = img.GetLength(0);
            if(N != img.GetLength(1))
                throw new Exception("not square matrix");
            if (N <= 1)
                return img;
            for (int i = 0; i < (N - 1) / 2.0f; i++)
            {
                for (int j = 0; j < N - 2 * i - 1; j++)
                {
                    int curr = img[i, i + j];
                    img[i, i + j] = img[N - 1 - i - j, i];
                    img[N - 1 - i - j, i] = img[N - 1 - i, N - 1 - i - j];
                    img[N - 1 - i, N - 1 - i - j] = img[i + j, N - 1 - i];
                    img[i + j, N - 1 - i] = curr;
                }
            }
            return img;
        }


        public static int[,] ZeroRowsCols(int[,] mx)
        {
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            int n = mx.GetLength(0);
            int m = mx.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mx[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (rows.Contains(i) || cols.Contains(j))
                    {
                        mx[i, j] = 0;
                    }
                }
            }
            return mx;
        }
    }
}

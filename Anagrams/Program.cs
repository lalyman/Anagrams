using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Program
    {
        public static void Anagrams(string s, int startindex, int endindex)
        {
            if (startindex == endindex)
            {
                Console.WriteLine(s);
            }
            else
            {
                for (int i = startindex; i <= endindex; i++)
                {
                    s = Swap(s, startindex, i);
                    Anagrams(s, startindex + 1, endindex); // recursive step
                    s = Swap(s, startindex, i); // backtrack

                }

            }

        }


        public static string Swap(string s, int i, int j)
        {
            // if i and j are sensible
            if (i >= 0 && j >= 0 && i < s.Length && j < s.Length)
            {
                char[] arr = s.ToCharArray();
                char tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                return new string(arr);
            }
            else
            {
                return s;
            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to produce anagrams!");
            string line = Console.ReadLine();
            Console.WriteLine();
            Anagrams(line, 0, line.Length - 1);

        }
    }
}

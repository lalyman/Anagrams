using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Anagrams
{
    class Program
    {
        public static List<string> Anagrams(string s)
        {
            return Anagrams(s, 0, s.Length - 1);
        }

        public static List<string> Anagrams(string s, int startindex, int endindex)
        {
            var tmp = new List<string>();
            if (startindex == endindex)
            {
                tmp.Add(s);
            }
            else
            {
                for (int i = startindex; i <= endindex; i++)
                {
                    s = Swap(s, startindex, i);
                    tmp.AddRange(Anagrams(s, startindex + 1, endindex)); // recursive step
                    s = Swap(s, startindex, i); // backtrack

                }

            }
            return tmp;
        }


        public static string Swap(string s, int i, int j)
        {
            // if i and j are not sensible
            if (i < 0 || j < 0 || i >= s.Length || j >= s.Length) return s;
            var arr = s.ToCharArray();
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
            return new string(arr);
        }


        static void Main()
        {
            Console.WriteLine("Please enter a string to produce anagrams!");
            string line = Console.ReadLine();
            Console.WriteLine();
            var output = Anagrams(line);
            output.ForEach(Console.WriteLine);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }


    [TestFixture]
    class ProgramTest

{
        [Test]
        public void SimpleWord()
        {
            const string input = "a";
            var tmp = new List<string> {input};
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"One letter test");

        }
        [Test]
        public void TwoLetterWord()
        {
            const string input = "ab";
            var tmp = new List<string> {"ab","ba"};
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"Two letter test");

        }
        [Test]
        public void ThreeLetterWord()
        {
            const string input = "abc";
            var tmp = new List<string> {"abc","acb","bac","bca","cab","cba"};
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"Three letter test");

        }
        [Test]
        public void FourLetterWord()
        {
            const string input = "abcd";
            var tmp = new List<string> {"abcd","abdc","acbd","acdb","adbc","adcb","bacd","badc","bcad","bcda","bdac","bdca","cabd","cadb","cbad","cbda","cdab","cdba","dabc","dacb","dbac","dbca","dcab","dcba"};
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"Four letter test");

        }
        [Test]
        public void Repeats()
        {
            const string input = "aa";
            var tmp = new List<string> {"aa","aa"};
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"Repeat test - expect all permutations even duplicate ones to come back");

        }
        [Test]
        public void Empty()
        {
            const string input = "";
            var tmp = new List<string>();
            Assert.That(Program.Anagrams(input),Is.EquivalentTo(tmp),"Empty list test");

        }
        [Test]
        public void NullTest()
        {
            Assert.Throws<NullReferenceException>(() => Program.Anagrams(null),"Null string should throw exception");

        }

       
}
}

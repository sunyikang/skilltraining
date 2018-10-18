using System;
using System.Collections.Generic;

namespace Medium
{
    public class Medium
    {
        static string Encoding(string samecharstr)
        {
            return samecharstr.Length.ToString() + samecharstr[0];
        }

        public static string RunLength(string str)
        {
            string newstr = "";
            char c = str[0];
            int left = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != c)
                {
                    newstr += Encoding(str.Substring(left, i - left));
                    c = str[i];
                    left = i;
                }

                if (i == str.Length - 1)
                {
                    newstr += Encoding(str.Substring(left, i - left + 1));
                }
            }    
            return newstr;
        }

        static int FindNextPrime(List<int> primes, int start)
        {
            bool isprime = true;
            foreach (int one in primes)
            {
                if (start % one == 0)
                {
                    isprime = false;
                }
            }

            if (isprime)
            {
                return start;
            }
            else
            {
                return FindNextPrime(primes, start + 1);
            }
        }

        public static int PrimeMover(int num)
        {
            List<int> primes = new List<int>();
            primes.Add(2);

            int start = 3;
            do
            {
                int next = FindNextPrime(primes, start);
                primes.Add(next);
                start = next + 1;
            }
            while(primes.Count < num);

            return primes[primes.Count - 1];
        }

        public static string PalindromeTwo(string str)
        { 
            // 1. kick out non-letter char, change upper to low
            string newstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (!char.IsLetter(c) || c == ' ')
                {
                    // do nothing
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                    }

                    newstr += c;
                }
            }

            // 2. compare
            for (int i = 0; i < newstr.Length && i < newstr.Length - i - 1; i++)
            {
                char left = newstr[i];
                char right = newstr[newstr.Length - 1 - i];
                if (left != right)
                {
                    return "false";
                }
            }
            return "true";
        }

        static int GetMaxRearrangedNum(int num)
        {
            string numstr = num.ToString();
            List<int> list = new List<int>();
            for (int i = 0; i < numstr.Length; i++)
            {
                list.Add(numstr[i]);
            }
            list.Sort();

            string newstr = "";
            for (int i = numstr.Length - 1; i >= 0; i--)
            {
                newstr += numstr[i];
            }

            return Convert.ToInt32(newstr);
        }

        static bool HasSameDigitals(string prime, string num)
        {
            for (int i = 0; i < prime.Length; i++)
            {
                char c = prime[i];

                bool find = false;
                for (int j = 0; j < num.Length; j++)
                {
                    if (c == num[j])
                    {
                        find = true;
                    }
                }

                if (!find)
                {
                    return false;
                }
            }

            return true;
        }

        static int CheckHasCombinationToBePrime(List<int> primes, string numstr)
        {
            int length = numstr.Length;

            for (int i = 0; i < primes.Count; i++)
            {
                string prime = primes[i].ToString();
                if (prime.Length == length)
                {
                    if (HasSameDigitals(prime, numstr))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public static int PrimeChecker(int num)
        {
            int newnum = GetMaxRearrangedNum(num);

            List<int> primes = new List<int>();
            primes.Add(2);

            int start = 3;
            do
            {
                int next = FindNextPrime(primes, start);
                primes.Add(next);
                start = next + 1;
            }
            while(primes[primes.Count - 1] < newnum);

            string numstr = num.ToString();
            return CheckHasCombinationToBePrime(primes, numstr);
        }

        //        public static void Main()
        //        {
        //            Console.WriteLine(RunLength("dffddsse"));
        //            Console.WriteLine(RunLength("dffddssee"));
        //
        //            Console.WriteLine(PrimeMover(16));
        //            Console.WriteLine(PalindromeTwo("A war at Tarawa!"));
        //            Console.WriteLine(PalindromeTwo("Noel - sees Leon"));
        //
        //            Console.WriteLine(PrimeChecker(98));
        //            Console.WriteLine(PrimeChecker(598));
        //            Console.WriteLine(PrimeChecker(103));
        //        }
    }
}


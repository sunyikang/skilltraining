using System;
using System.Collections.Generic;

namespace algorithm
{
    public class PrimeCalculator
    {
        static bool IsPrime(int num, List<int> primes)
        {
            foreach (int p in primes)
            {
                if (num % p == 0)
                    return false;
            }
            return true;
        }

        static void GetPrimes(int num, ref List<int> primes)
        {
            for (int i = 2; i < (int)(Math.Sqrt(num)); i++)
            {
                if (IsPrime(i, primes))
                {
                    primes.Add(i);
                }
            }
        }

        public static bool PrimeTime(int num)
        {
            if (num < 2)
                return false;

            List<int> primes = new List<int>();
            GetPrimes(num, ref primes);

            foreach (int p in primes)
            {
                if (num % p == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}


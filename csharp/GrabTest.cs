using System;
using System.Collections.Generic;

namespace GrabTest
{
    public class GrabTest
    {
        const int T1Price = 2;
        const int T2Price = 7;
        const int T3Price = 25;

        int FindFirstFour(int[] A, int start, int end)
        {
            for (int i = start; i < A.Length - 4 && i <= end; i++)
            {
                int left = A[i];
                int right = A[i + 3];

                if (right - left < 7)
                {
                    return i;
                }
            }

            return -1;
        }

        int FindSevenEnd(int[] A, int start)
        {
            if (start < 0)
                return -1;
            
            int startvalue = A[start];
            if (start + 6 < A.Length)
            {
                for (int i = start; i < A.Length; i++)
                {
                    int endvalue = A[i];
                    if (endvalue > startvalue + 6)
                    {
                        return i;
                    }
                }   
            }
            return -1;
        }

        public int ComputeMinPrice(int[] A, int start)
        {
            int totalMinPrice = int.MaxValue;
            int leftPrice = 0;
            int middlePrice = 0;
            int rightPrice = 0;

            int startOfFour = FindFirstFour(A, start, A.Length - 1);
            int endOfFour = FindSevenEnd(A, startOfFour);
            int newStartOfFour = endOfFour;

            // move check and find the mininum price
            if (startOfFour != -1)
            {
                do
                {
                    // get current min value
                    leftPrice = (startOfFour - start) * T1Price;
                    middlePrice = T2Price;
                    if (endOfFour != -1)
                    {
                        rightPrice = ComputeMinPrice(A, newStartOfFour);
                    }

                    if (totalMinPrice > leftPrice + middlePrice + rightPrice)
                    {
                        totalMinPrice = leftPrice + middlePrice + rightPrice;
                    }

                    newStartOfFour++;
                }
                while(endOfFour != -1 &&
                      newStartOfFour + 4 < A.Length &&
                      A[newStartOfFour + 4] - A[newStartOfFour] < 7 &&
                      newStartOfFour - startOfFour < 4);
            }
            else
            {
                totalMinPrice = (A.Length - start) * T1Price;
            }

            return totalMinPrice;
        }

        public int solution(int[] A)
        {
            int minPrice = ComputeMinPrice(A, 0);
            if (minPrice > T3Price)
            {
                return T3Price;
            }
            return minPrice;
        }
    }


    class Solution
    {
        const int FeeEntrance = 2;
        const int FeeFirstHour = 3;
        const int FeeLeftHour = 4;

        int GetMinutes(string str)
        {
            string hour = str.Substring(0, 2);
            string minute = str.Substring(3, 2);

            if (hour[0] == '0')
            {
                hour = hour[1].ToString();
            }
            if (minute[0] == '0')
            {
                minute = minute[1].ToString();
            }

            int totalMin = Convert.ToInt32(hour) * 60 + Convert.ToInt32(minute);

            return totalMin;
        }

        public int solution(string E, string L)
        {
            int etime = GetMinutes(E);
            int ltime = GetMinutes(L);
            int timelength = ltime - etime;

            if (timelength < 60)
            {
                return FeeEntrance + FeeFirstHour;
            }
            else
            {
                // here take care
                int rest = (timelength - 60) % 60;
                int lefthour = (timelength - 60) / 60;
                lefthour += (rest > 0) ? 1 : 0;

                return FeeEntrance + FeeFirstHour + FeeLeftHour * lefthour;
            }
        }
    }

    class Solution2
    {
        void FindLevelCount(int[] T, int city, int level, ref List<int> levelcounts)
        {
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] == city && i != city)
                {
                    if (levelcounts.Count <= level)
                    {
                        levelcounts.Add(1);
                    }
                    else
                    {
                        levelcounts[level]++;
                    }

                    FindLevelCount(T, i, level + 1, ref levelcounts);
                }
            }
        }

        public int[] solution(int[] T)
        {
            int capital = -1;
            for (int i = 0; i < T.Length; i++)
            {
                if (i == T[i])
                {
                    capital = i;
                }
            }

            List<int> levelcounts = new List<int>();

            FindLevelCount(T, capital, 0, ref levelcounts);

            return levelcounts.ToArray();
        }
    }

    class Program2
    {
        // public static void Main()
        // {
        //     GrabTest one = new GrabTest();

        //     int[] A0 = { 1, 2 };
        //     Console.WriteLine(one.solution(A0));

        //     int[] A1 = { 1, 3, 5, 8, 21, 22, 23, 25, 26, 30 };
        //     Console.WriteLine(one.solution(A1));

        //     int[] A2 = { 1, 3, 5, 8, 11, 12, 13, 14, 15, 21, 22, 23, 25, 26, 30 };
        //     Console.WriteLine(one.solution(A2));

        //     int[] A3 = { 1, 2, 4, 5, 7, 29, 30 };
        //     Console.WriteLine(one.solution(A3));

        //     Solution two = new Solution();
        //     Console.WriteLine(two.solution("10:00", "13:21"));
        //     Console.WriteLine(two.solution("10:01", "13:01"));
        //     Console.WriteLine(two.solution("09:42", "11:42"));

        //     int[] A = { 4, 1, 4, 2, 1 };
        //     Solution2 three = new Solution2();
        //     int[] X = three.solution(A);
        //     for (int i = 0; i < X.Length; i++)
        //     {
        //         Console.Write(X[i] + " / ");
        //     }
        // }
    }
}


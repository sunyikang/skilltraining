using System;
using System.Collections.Generic;

namespace Graph
{
    //https://www.hackerrank.com/domains/algorithms/dynamic-programming

    public class DynamicProgramming
    {
        static void AddSumToMap(HashSet<int> set, int value)
        {
            HashSet<int> newset = new HashSet<int>();

            foreach (int one in set)
            {
                int newKey = one + value;
                if (!set.Contains(newKey))
                {
                    newset.Add(newKey);
                }
            }

            set.UnionWith(newset);
        }

        static string ArrayAddition(int[] arr)
        {
            // 1. max
            List<int> list = new List<int>(arr);
            list.Sort();

            // 2. set
            HashSet<int> set = new HashSet<int>();
            set.Add(0);

            // 3. all sum
            int length = list.Count - 1;
            int maxNum = list[length];
            for (int i = 0; i < length; i++)
            {
                AddSumToMap(set, list[i]);
                if (set.Contains(maxNum))
                {
                    return "true";
                }
            }

            return "false";
        }
        
        // public static void Main()
        // {  
        //     // keep this function call here
        //     int[] array = { 5, 7, 16, 1, 2 };
        //     //int[] array = { 3, 5, -1, 8, 12 };

        //     Console.WriteLine(ArrayAddition(array));
        // }
    }
}


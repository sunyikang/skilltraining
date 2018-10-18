using System;
using System.Collections.Generic;

namespace algorithm
{
    public class Sorting
    {
        static int timeCostNum = 0;

        static void StartTimeCost()
        {
            timeCostNum = 0;
        }

        static void TimeCost(int time = 1)
        {
            timeCostNum += time;
        }

        static void EndTimeCost()
        {
            Console.WriteLine("Time Cost is " + timeCostNum + "\n");
            timeCostNum = 0;
        }

        static void Swap(int[] array, int x, int y)
        {
            TimeCost(3);
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        static void DutchNationalFlag(int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            for (int i = 0; i <= high; i++)
            {
                if (array[i] == 0)
                    Swap(array, low++, i--);

                if (array[i] == 2)
                    Swap(array, i--, high--);
            }
        }

        // compare the time complexity for all sorting algorithms:
        //http://cs.stackexchange.com/questions/13106/why-is-selection-sort-faster-than-bubble-sort
        //https://en.wikipedia.org/wiki/The_Art_of_Computer_Programming

        static void BubbleSort(int[] array)
        {
            //https://coderbyte.com/algorithm/implement-bubble-sort

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        static void InsertToFront(int[] array, int index)
        {
            TimeCost();
            int temp = array[index];
            for (int i = index - 1; i >= 0; i--)
            {
                TimeCost();
                array[i + 1] = array[i];
                if (i == 0 || (array[i - 1] <= temp && temp <= array[i]))
                {
                    TimeCost();
                    array[i] = temp;
                    break;
                }
            }
        }

        static void InsertSort(int[] array)
        {
            //https://en.wikipedia.org/wiki/Insertion_sort

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    InsertToFront(array, i);
                }
            }
        }

        static int FindMinIndex(int[] array, int start)
        {
            int minindex = start;
            int min = array[start];
            for (int i = start; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    TimeCost();
                    min = array[i];
                    minindex = i;
                }
            }
            return minindex;
        }

        static void SelectionSort(int[] array)
        {
            //https://en.wikipedia.org/wiki/Selection_sort
            //http://cs.stackexchange.com/questions/13106/why-is-selection-sort-faster-than-bubble-sort

            for (int i = 0; i < array.Length; i++)
            {
                int minindex = FindMinIndex(array, i);
                Swap(array, i, minindex);
            }
        }


        /*
             https://coderbyte.com/CodingArea/Editor.php?ct=Wave%20Sorting&lan=Csharp&o=true

             Challenge
             
                Using the C# language, have the function WaveSorting(arr) take the array of positive integers stored in arr and return the string true if the numbers can be arranged in a wave pattern: a1 > a2 < a3 > a4 < a5 > ..., otherwise return the string false. For example, if arr is: [0, 1, 2, 4, 1, 4], then a possible wave ordering of the numbers is: [2, 0, 4, 1, 4, 1]. So for this input your program should return the string true. The input array will always contain at least 2 elements. More examples are given below as sample test cases. 
                
             Sample Test Cases
             
                Input:0, 1, 2, 4, 1, 1, 1
                Output:"false"

                Input:0, 4, 22, 4, 14, 4, 2
                Output:"true"
        */

        static string WaveSort(int[] array)
        {

            int max = 0;
            Dictionary<int,int> map = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (map.ContainsKey(array[i]))
                {
                    map[array[i]]++;
                    if (map[array[i]] > max)
                    {
                        max = map[array[i]];
                    }
                }
                else
                {
                    map.Add(array[i], 1);
                }
            }

            return (max * 2 <= array.Length) ? "true" : "false";
        }

        /*
        public static void Main(string[] args)
        {
            string str = "";

            // Dutch national flag
            {
                int[] array = { 1, 2, 0, 0, 2, 2, 1 };
                str = string.Join(",", array);
                Console.WriteLine(str);

                DutchNationalFlag(array);
                str = string.Join(",", array);
                Console.WriteLine(str);

                int[] array2 = { 2, 2, 2, 0, 0, 0, 1, 1 };
                str = string.Join(",", array2);
                Console.WriteLine(str);
                DutchNationalFlag(array2);
                str = string.Join(",", array2);
                Console.WriteLine(str + "\n");
            }

            // bubble sort
            StartTimeCost();
            {
                //int[] array = { 8, 7, 6, 5, 3, 5, 1, 0, 8, 7, 6, 5, 3, 5, 1, 0 };
                int[] array = { 3, 1, 2 };
                str = string.Join(",", array);
                Console.WriteLine(str);
                BubbleSort(array);
                str = string.Join(",", array);
                Console.WriteLine(str + "\n");
            }
            EndTimeCost();

            // insert sort
            StartTimeCost();
            {
                //int[] array = { 8, 7, 6, 5, 3, 5, 1, 0, 8, 7, 6, 5, 3, 5, 1, 0 };
                int[] array = { 3, 1, 2 };
                str = string.Join(",", array);
                Console.WriteLine(str);
                InsertSort(array);
                str = string.Join(",", array);
                Console.WriteLine(str + "\n");
            }
            EndTimeCost();

            // selection sort
            StartTimeCost();
            {
                //int[] array = { 8, 7, 6, 5, 3, 5, 1, 0, 8, 7, 6, 5, 3, 5, 1, 0 };
                int[] array = { 3, 1, 2 };
                str = string.Join(",", array);
                Console.WriteLine(str);
                SelectionSort(array);
                str = string.Join(",", array);
                Console.WriteLine(str + "\n");
            }
            EndTimeCost();

            // wave sort
            {
                //int[] array = { 8, 7, 6, 5, 3, 5, 1, 0, 8, 7, 6, 5, 3, 5, 1, 0 };
                int[] array = { 0, 1, 2, 4, 1, 1, 1 };
                //int[] array = { 0, 4, 22, 4, 14, 4, 2 };
                str = string.Join(",", array);
                Console.WriteLine(str);
                string result = WaveSort(array);
                Console.WriteLine(result + "\n");
            }
        }
        */
    }
}


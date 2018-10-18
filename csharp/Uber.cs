using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UberPractice
{
    public class Solution
    {
        private static Dictionary<int, int> ComputeNoteNumbers(Dictionary<int, int> bankNotes, Stack<int> bankNoteValues, int target)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            int biggestValue = bankNoteValues.Pop();
            do
            {

                if (target < biggestValue)
                {
                    if (bankNoteValues.Count > 0)
                        biggestValue = bankNoteValues.Pop();
                }
                else
                {
                    if (bankNotes[biggestValue] > 0)
                    {
                        // decrease the storage
                        target -= biggestValue;
                        bankNotes[biggestValue]--;

                        // record it in result
                        if (result.ContainsKey(biggestValue))
                        {
                            result[biggestValue]++;
                        }
                        else
                        {
                            result.Add(biggestValue, 1);
                        }
                    }
                    else
                    {
                        if (bankNoteValues.Count > 0)
                            biggestValue = bankNoteValues.Pop();
                    }
                }
            }
            while (target != 0);

            return result;
        }

        // public static void Main()
        // {
        //     // init
        //     Dictionary<int, int> bankNotes = new Dictionary<int, int>();
        //     bankNotes.Add(5, 0);
        //     bankNotes.Add(10, 2);
        //     bankNotes.Add(50, 1);
        //     bankNotes.Add(100, 3);
        //     int target = 180;
        //     Stack<int> bankNoteValues = new Stack<int>();
        //     bankNoteValues.Push(5);
        //     bankNoteValues.Push(10);
        //     bankNoteValues.Push(50);
        //     bankNoteValues.Push(100);

        //     // output
        //     Dictionary<int, int> result = ComputeNoteNumbers(bankNotes, bankNoteValues, target);

        //     // print
        //     foreach (KeyValuePair<int, int> pair in result)
        //     {
        //         Console.WriteLine($"key = {pair.Key} ; value = {pair.Value}");
        //     }
        // }
    }
}

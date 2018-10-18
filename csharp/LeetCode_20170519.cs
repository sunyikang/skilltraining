using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode_20170519
{
    public class Solution
    {
        private IList<int> GeneratePerfectSquares(int n)
        {
            IList<int> result = new List<int>();
            int i = 1;
            int square = 0;

            do
            {
                square = i * i;
                i++;
                if(square <= n)
                    result.Add(square);
            }
            while(square <= n);

            return result;
        }

        private void FillInStack(IList<int> squares, int maxIndex, Stack<int> stack)
        {
            stack.Clear();

            for(int i = 0; i <= maxIndex; i++)
            {
                stack.Push(squares[i]);
            }
        }

        private int PayFromTop(Stack<int> stack, int target)
        {
            int num = 0;
            
            do
            {
                int maxNote = stack.Pop();
                num += (int)Math.Floor((float)target / maxNote);
                target = target % maxNote;                
            }
            while(target != 0);

            return num;
        }

        public int NumSquares(int n)
        {
            IList<int> squares = GeneratePerfectSquares(n);

            int leastNum = Int16.MaxValue;
            Stack<int> stack = new Stack<int>();
            for(int i = squares.Count - 1; i >= 0; i--)
            {
                FillInStack(squares, i, stack);

                int num = PayFromTop(stack, n);

                if(num == 0) continue;
                else leastNum = leastNum <= num ? leastNum : num;
            }
            
            return leastNum;
        }
    }

    public class Program
    {
        // public static void Main()
        // {
        //     Solution solution = new Solution();

        //     Console.WriteLine(solution.NumSquares(43).ToString());
        //     Console.WriteLine(solution.NumSquares(1).ToString());
        //     Console.WriteLine(solution.NumSquares(12).ToString());
        //     Console.WriteLine(solution.NumSquares(13).ToString());
        //     Console.WriteLine(solution.NumSquares(17).ToString());
        //     Console.WriteLine(solution.NumSquares(18).ToString());
        //     Console.WriteLine(solution.NumSquares(600).ToString());
        // }
    }
}
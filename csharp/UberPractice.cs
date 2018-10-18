using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Uber
{
    public class Series
    {
        private Stack<string> stack = new Stack<string>();

        public void ParseFront()
        {
            // stack full, there must be 6 members in stack
            string op3 = PopOperation();
            int v3 = PopNumber();
            string op2 = PopOperation();
            int v2 = PopNumber();
            string op1 = PopOperation();
            int v1 = PopNumber();

            if (op1 == "*")
            {
                v2 = v1 * v2;
                stack.Push(v2.ToString());
                stack.Push(op2);
                stack.Push(v3.ToString());
                stack.Push(op3);
            }
            else
            {
                if (op2 == "*")
                {
                    v2 = v2 * v3;
                    stack.Push(v1.ToString());
                    stack.Push(op1);
                    stack.Push(v2.ToString());
                    stack.Push(op3);
                }
                else
                {
                    if (op2 == "+") v2 = v1 + v2;
                    else v2 = v1 - v2;

                    stack.Push(v2.ToString());
                    stack.Push(op2);
                    stack.Push(v3.ToString());
                    stack.Push(op3);
                }
            }
        }

        public int ParseAll()
        {
            Debug.Assert(stack.Count == 5 || stack.Count == 3, "the final parse must have odd number");

            int result = -1;
            Stack<string> clonedStack = new Stack<string>(stack.Reverse());
            {
                if (stack.Count == 3)
                {
                    int v2 = PopNumber();
                    string op = PopOperation();
                    int v1 = PopNumber();

                    if (op == "*") result = v1 * v2;
                    else if (op == "+") result = v1 + v2;
                    else if (op == "-") result = v1 - v2;
                    else Debug.Fail($"op value is wrong : {op}");
                }
                else if (stack.Count == 5)
                {
                    int v3 = PopNumber();
                    string op2 = PopOperation();
                    int v2 = PopNumber();
                    string op1 = PopOperation();
                    int v1 = PopNumber();

                    if (op1 == "*")
                    {
                        v2 = v1 * v2;

                        if (op2 == "*") result = v3 * v2;
                        else if (op2 == "+") result = v2 + v3;
                        else result = v2 - v3;
                    }
                    else
                    {
                        // compute v2 and v3 firstly
                        if (op2 == "*") v2 = v3 * v2;
                        else if (op2 == "+") v2 = v2 + v3;
                        else v2 = v2 - v3;

                        // compute v1 and v2
                        if (op1 == "+") result = v1 + v2;
                        else result = v1 - v2;
                    }
                }
            }
            stack = new Stack<string>(clonedStack.Reverse());

            return result;
        }

        private int PopNumber()
        {
            int num = -1;
            bool success = Int32.TryParse(stack.Pop(), out num);
            Debug.Assert(success, $"num is invalid : {num}");
            return num;
        }

        private string PopOperation()
        {
            string operationStr = stack.Pop();
            Debug.Assert(operationStr == "#" || operationStr == "+" || operationStr == "-" || operationStr == "*", $"operation is invalid : {operationStr}");
            return operationStr;
        }

        public bool IsStackFull()
        {
            if (stack.Count == 6)
                return true;
            return false;
        }

        public void PushNumber(char numberChar)
        {
            Debug.Assert(char.IsNumber(numberChar));

            if (stack.Count == 0 || stack.Peek() != "#")
            {
                string str = "";
                str += numberChar;
                stack.Push(str);
            }
            else
            {
                string peek = stack.Peek();
                stack.Pop();
                {
                    int v = this.PopNumber();
                    int newNum = (int)char.GetNumericValue(numberChar);
                    v = v * 10 + newNum;
                    stack.Push(v.ToString());
                }
                stack.Push("#");
            }
        }

        public void PushOperation(char letter)
        {
            string str = "";
            str += letter;
            stack.Push(str);
        }

        public void Pop()
        {
            stack.Pop();
        }
    }

    public class Solution
    {
        void Dfs(string num, int target, IList<char> operations, IList<string> result, int pos, string cur, Series series)
        {
            if (pos == num.Length - 1)
            {
                series.PushNumber(num[pos]);
                {
                    if (series.ParseAll() == target)
                        result.Add(cur.Replace("#", ""));
                }
                series.Pop();
            }
            else
            {
                // check isValidParse
                if (series.IsStackFull())
                {
                    series.ParseFront();
                }

                // push number
                series.PushNumber(num[pos]);
                cur += num[pos];

                foreach (char operation in operations)
                {
                    // push operation
                    series.PushOperation(operation);
                    cur += operation;

                    // continue next layer of Dfs
                    Dfs(num, target, operations, result, pos + 1, cur, series);

                    // recover the series
                    cur = cur.Remove(cur.Length - 1);
                    series.Pop();
                }
            }
        }

        public IList<string> AddOperators(string num, int target)
        {
            IList<string> result = new List<string>();
            if (num.Length < 1) return result;

            // init
            Series series = new Series();
            string cur = "";
            IList<char> operations = new List<char>();
            operations.Add('+');
            operations.Add('-');
            operations.Add('*');
            operations.Add('#');

            // work
            Dfs(num, target, operations, result, 0, cur, series);

            return result;
        }

        // public static void Main()
        // {
        //     Solution solution = new Solution();
        //     IList<string> list = solution.AddOperators("105", 5);
        //     foreach (string one in list)
        //     {
        //         Console.WriteLine(one);
        //     }
        // }
    }
}

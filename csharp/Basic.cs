using System;
using System.Collections.Generic;

namespace Basic
{
    public class Basic
    {
        public static string FirstFactorial(int num)
        { 
            long result = 1;
            for (int i = num; i > 0; i--)
            {
                result *= i;
            }
            return result.ToString();
        }

        static int GetMinFromTime(string str)
        {
            bool am = true;
            int middleindex = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ':')
                {
                    middleindex = i;
                }
                else if (str[i] == 'a')
                {
                    am = true;
                }
                else if (str[i] == 'p')
                {
                    am = false;
                }
            }
            str = str.Replace("am", "");
            str = str.Replace("pm", "");
            string h = str.Substring(0, middleindex);
            string m = str.Substring(middleindex + 1, str.Length - middleindex - 1);
            if (h == "12")
            {
                h = "0";
            }
            int value = Convert.ToInt32(h) * 60 + Convert.ToInt32(m);
            value += am ? 0 : 12 * 60;
            return value;
        }

        public static string CountingMinutesI(string str)
        {
            int indexdash = -1;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '-')
                {
                    indexdash = i;
                }
            }

            string left = str.Substring(0, indexdash);
            string right = str.Substring(indexdash + 1, str.Length - indexdash - 1);

            int leftvalue = GetMinFromTime(left);
            int rightvalue = GetMinFromTime(right);

            int value = rightvalue - leftvalue;
            if (value < 0)
            {
                value += 24 * 60;
            }
            return value.ToString();
        }

        public static int MeanMode(int[] arr)
        { 
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int mean = sum / arr.Length;

            Dictionary<int,int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]]++;
                }
                else
                {
                    map.Add(arr[i], 1);
                }
            }

            int maxtime = 0;
            int theKey = -1;
            foreach (KeyValuePair<int,int> one in map)
            {
                if (one.Value > maxtime)
                {
                    maxtime = one.Value;
                    theKey = one.Key;
                }    
            }

            if (theKey == mean)
            {
                return 1;
            }
            return 0;   
        }

        static bool IsOdd(char c)
        {
            int num = Convert.ToInt32(c);
            if (num % 2 == 1)
                return true;
            return false;
        }

        public static string DashInsert(string str)
        {
            for (int i = str.Length - 2; i >= 0; i--)
            {
                if (IsOdd(str[i + 1]) && IsOdd(str[i]))
                {
                    str = str.Substring(0, i + 1) + "-" + str.Substring(i + 1, str.Length - i - 1);
                }
            }
            return str;
        }

        public static string SwapCase(string str)
        { 
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    char newc = char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c);
                    str = str.Substring(0, i) + newc + str.Substring(i + 1, str.Length - i - 1);
                }
            }
            return str;
        }

        public static string NumberAddition(string str)
        {
            int sum = 0;
            int left = -1;

            bool finddigital = false;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (!finddigital && char.IsDigit(c))
                {
                    finddigital = true;
                    left = i;
                }

                if (finddigital && (!char.IsDigit(c) || i == str.Length - 1))
                {
                    string numstr = "";
                    if (i == str.Length - 1 && char.IsDigit(c))
                    {
                        numstr = str.Substring(left, i - left + 1);
                    }
                    else
                    {
                        numstr = str.Substring(left, i - left);
                    }
                    left = -1;
                    sum += Convert.ToInt32(numstr);
                    finddigital = false;
                }
            }
            return sum.ToString();
        }

        static int IsLeftSmallerThanRight(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return -1;
            }
            else if (x.Length < y.Length)
            {
                return 1;
            }

            return 0; // means x == y
        }

        public static string ThirdGreatest(string[] strArr)
        {
            List<string> greatlist = new List<string>();
            greatlist.Add(strArr[0]);
            greatlist.Add(strArr[1]);
            greatlist.Add(strArr[2]);
            greatlist.Sort(IsLeftSmallerThanRight);

            if (strArr.Length > 3)
            {
                for (int i = 3; i < strArr.Length; i++)
                {
                    string one = strArr[i];
                    if (IsLeftSmallerThanRight(greatlist[2], one) == 1)
                    {
                        greatlist.RemoveAt(2);
                        greatlist.Add(one);
                        greatlist.Sort(IsLeftSmallerThanRight);
                    }
                }   
            }

            return greatlist[2];
        }

        public static string PowersofTwo(int num)
        { 
            if (num < 1)
                return "false";
            
            for (int i = num; i != 2; i /= 2)
            {
                if (i % 2 != 0)
                {
                    return "false";
                }
            }
            return "true";
        }

        static void GetAdditiveResult(string str, ref int time)
        {
            if (str.Length != 1)
            {
                time++;

                int sum = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    sum += (int)char.GetNumericValue(c);
                }

                GetAdditiveResult(sum.ToString(), ref time);
            }
        }

        public static int AdditivePersistence(int num)
        { 
            string str = Convert.ToString(num);

            int time = 0;
            GetAdditiveResult(str, ref time);

            return time;
        }


        static void GetMultipleResult(string str, ref int time)
        {
            if (str.Length != 1)
            {
                time++;

                int mul = 1;
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    mul *= (int)char.GetNumericValue(c);
                }

                GetMultipleResult(mul.ToString(), ref time);
            }
        }

        public static int MultiplicativePersistence(int num)
        { 
            string str = Convert.ToString(num);

            int time = 0;
            GetMultipleResult(str, ref time);

            return time;
        }

        public int FindBalanceIndex(int[] A)
        {
            if (A.Length == 0)
                return -1;

            long left = 0;
            long right = 0;
            for (int i = 1; i < A.Length; i++)
            {
                right += A[i];
            }

            if (left == right && left < int.MaxValue && right < int.MaxValue)
            {
                return 0;
            }

            for (int p = 1; p < A.Length; p++)
            {
                left += A[p - 1];
                right -= A[p];
                if (left == right && left < int.MaxValue && right < int.MaxValue)
                {
                    return p;
                }
            }

            return -1;
        }

        static void ReplaceBracketWithCombine(ref string str, int num)
        {
            string value = "(" + num.ToString() + ")";
            num += 2;

            if (str.Contains(value))
            {
                str = str.Replace(value, num.ToString());
                ReplaceBracketWithCombine(ref str, num);
            }

            return;
        }

        public static int GetMaxValidBracket(string S, int K)
        {
            // 0. validation check 
            if (S.Length == 0)
                return 0;

            // 1. to ) ) 4 ) ( 4 ( ( (
            int left = 0;
            int stackvalue = 0;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];

                if (stack.Count == 0)
                {
                    if (c == ')')
                    {
                        if (stackvalue != 0)
                        {
                            S = S.Substring(0, left + 1) + stackvalue.ToString() + S.Substring(i, S.Length - i);

                            stackvalue = 0;
                            left += stackvalue.ToString().Length + 1;
                            i = left;
                        }
                        else
                        {
                            left = i;
                        }
                    }
                    else if (c == '(')
                    {
                        stack.Push('(');
                    }
                }
                else
                {
                    if (c == ')')
                    {
                        stack.Pop();
                        stackvalue += 2;
                    }
                    else if (c == '(')
                    {
                        stack.Push('(');
                    }
                }
            }

            Console.WriteLine(S);


            // 2. to valid value:  6    4    6    8
            //       distance   :    2    4    6
            List<int> validvalues = new List<int>();
            List<int> distances = new List<int>();

            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];

                if (char.IsDigit(c))
                {
                    
                }


                int distance = 0;
                if (c == '(' || c == ')')
                {
                    distance++;
                }
                else
                {
                    distances.Add(distance);
                    distance = 0;
                    validvalues.Add((int)char.GetNumericValue(c));
                }
            }

            // print another list items.
            for (int i = 0; i < validvalues.Count; i++)
            {
                Console.Write("/" + validvalues[i]);
            }
            Console.WriteLine("");
            for (int i = 0; i < validvalues.Count; i++)
            {
                Console.Write("/" + distances[i]);
            }

            // 3. given K add from left to right and add result to list

            // 4. sort the list, and find the max valid value

            return 1;
        }

        //        public static void Main()
        //        {
        //            string S = ")()()((()))(((()))))()))))(((";
        //            int K = 2;
        //            Console.WriteLine(GetMaxValidBracket(S, K));
        //        }

        public static string OffLineMinimum(string[] strArr)
        {
            List<int> resultList = new List<int>();
            List<int> list = new List<int>();

            for (int i = 0; i < strArr.Length; i++)
            {
                string c = strArr[i];
                if (c != "E")
                {
                    list.Add(Convert.ToInt32(c));
                }
                else
                {
                    list.Sort();
                    int min = list[0];
                    list.RemoveAt(0);
                    resultList.Add(min);
                }
            }

            string result = "";
            foreach (int one in resultList)
            {
                result += one.ToString() + ",";
                Console.WriteLine(one);   
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        //        public static void Main()
        //        {
        //            string[] strArry = { "4", "E", "1", "E", "2", "E", "3", "E" };
        //            Console.WriteLine(OffLineMinimum(strArry));
        //        }

        public static int ChangingSequence(int[] arr)
        {
            if (arr.Length < 3)
                return -1;
            
            bool increase = arr[0] < arr[1];
            for (int i = 1; i < arr.Length; i++)
            {
                if ((increase && arr[i - 1] > arr[i]) || (!increase && arr[i - 1] < arr[i]))
                {
                    return i - 1;
                }
            }

            return -1;
        }

        //        public static void Main()
        //        {
        //            int[] arr = { 5, 4, 3, 2, 10, 11 };
        //            Console.WriteLine(ChangingSequence(arr));
        //        }

        public static string OverlappingRanges(int[] arr)
        {
            int duplicatenum = 0;
            List<int> list = new List<int>();
            for (int i = arr[0]; i <= arr[1]; i++)
            {
                list.Add(i);
            }
            for (int i = arr[2]; i <= arr[3]; i++)
            {
                if (list.Contains(i))
                {
                    duplicatenum++;
                }
            }

            if (duplicatenum == arr[4])
                return "true";
            return "false";
        }

        //        public static void Main()
        //        {
        //            int[] arr = { 1, 8, 2, 4, 4 };
        //            Console.WriteLine(OverlappingRanges(arr));
        //        }
        //
        public static string Superincreasing(int[] arr)
        { 
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (sum > arr[i])
                {
                    return "false";
                }
                sum += arr[i];
            }
            return "true";
        }
        //
        //        public static void Main()
        //        {
        //            int[] arr = { 1, 2, 3, 4 };
        //            Console.WriteLine(Superincreasing(arr));
        //        }

        public static int HammingDistance(string[] strArr)
        { 
            int difference = 0;
            string left = strArr[0];
            string right = strArr[1];

            for (int i = 0; i < left.Length; i++)
            {
                char up = left[i];
                char down = right[i];

                if (up != down)
                {
                    difference++;
                }
            }
            return difference;
        }

        //        public static void Main()
        //        {
        //            string[] strarr = { "helloworld", "worldhello" };
        //            Console.WriteLine(HammingDistance(strarr));
        //        }

        public static int RectangleArea(string[] strArr)
        {
            int minX = int.MaxValue;
            int maxX = int.MinValue;
            int minY = int.MaxValue;
            int maxY = int.MinValue;

            for (int i = 0; i < strArr.Length; i++)
            {
                string str = strArr[i];
                char left = Convert.ToChar(str.Substring(1, 1));
                char right = Convert.ToChar(str.Substring(3, 1));

                int x = (int)char.GetNumericValue(left);
                int y = (int)char.GetNumericValue(right);

                minX = (minX > x) ? x : minX;
                maxX = (maxX < x) ? x : maxX;

                minY = (minY > y) ? y : minY;
                maxY = (maxY < y) ? y : maxY;
            }

            int area = (maxX - minX) * (maxY - minY);
            return area;
        }

        //        public static void Main()
        //        {
        //            string[] strarr = { "(1 1)", "(1 3)", "(3 1)", "(3 3)" };
        //            Console.WriteLine(RectangleArea(strarr));
        //        }

        public static string BitwiseOne(string[] strArr)
        {
            string left = strArr[0];
            string right = strArr[1];
            string result = "";

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] == '0' && right[i] == '0')
                    result += "0";
                else
                    result += "1";
            }

            return result;
        }

        //        public static void Main()
        //        {
        //            string[] strarr = { "00011", "01010" };
        //            Console.WriteLine(BitwiseOne(strarr));
        //        }
        //

        public static string OtherProducts(int[] arr)
        {
            int all = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                all *= arr[i];
            }

            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(all / arr[i]);
            }

            string result = list[0].ToString();
            for (int i = 1; i < list.Count; i++)
            {
                result += "-" + list[i].ToString();
            }
            return result;
        }

        //        public static void Main()
        //        {
        //            int[] arr = { 3, 1, 2, 6 };
        //            Console.WriteLine(OtherProducts(arr));
        //        }

        /*
        // public static void Main()
        // {
        //     int A = 8;
        //     Console.WriteLine(FirstFactorial(A));

        //     string time = "12:30pm-12:00am";
        //     Console.WriteLine(CountingMinutesI(time));

        //     string time2 = "1:23am-1:08am";
        //     Console.WriteLine(CountingMinutesI(time2));

        //     int[] array = { 1, 2, 3 };
        //     Console.WriteLine(MeanMode(array));

        //     int[] array2 = { 4, 4, 4, 6, 2 };
        //     Console.WriteLine(MeanMode(array2));

        //     string str = "94453252";
        //     Console.WriteLine(DashInsert(str));

        //     str = "Hello World";
        //     Console.WriteLine(SwapCase(str));

        //     str = "10 2One Number*1*";
        //     Console.WriteLine(NumberAddition(str));

        //     string[] arraylist = { "coder", "byte", "code" };
        //     Console.WriteLine(ThirdGreatest(arraylist));

        //     string[] arraylist2 = { "abc", "defg", "z", "hijk" };
        //     Console.WriteLine(ThirdGreatest(arraylist2));

        //     Console.WriteLine(PowersofTwo(8));
        //     Console.WriteLine(PowersofTwo(22));

        //     Console.WriteLine(AdditivePersistence(2718));

        //     Console.WriteLine(MultiplicativePersistence(39));

        //     int[] A = new int[]{ -1, 2, 3, -4 };
        //     int[] A1 = new int[]{ 2147483647, 2147483647, 0, -2 };
        //     Console.WriteLine(solution(A1));
        // }
        */
    }
}


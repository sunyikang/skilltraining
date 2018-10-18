using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public string FrequencySort(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (map.Keys.Contains(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in map.OrderByDescending(r => r.Value))
            {
                for (int i = 0; i < item.Value; i++)
                {
                    result.Append(item.Key.ToString());
                }
            }

            return result.ToString();
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = 0; k != i && k < nums.Length; k++)
                {
                    if (nums[i] + nums[k] == target)
                    {
                        int[] ret = { i, k };
                        return ret;
                    }
                }
            }
            return null;
        }

        public IList<IList<int>> ThreeSum_Slow(int[] nums)
        {
            IList<IList<int>> matrix = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = 0; k != i && k < nums.Length; k++)
                {
                    for (int j = 0; j != i && j != k && j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            List<int> list = new List<int>() { nums[i], nums[j], nums[k] };
                            list.Sort();

                            bool duplicate = false;
                            for (int m = 0; m < matrix.Count(); m++)
                            {
                                IList<int> oldlist = matrix[m];
                                if (list[0] == oldlist[0] && list[1] == oldlist[1] && list[2] == oldlist[2])
                                {
                                    duplicate = true;
                                }
                            }

                            if (!duplicate)
                                matrix.Add(list);
                        }
                    }
                }
            }

            return matrix;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 3)
                return result;

            List<int> list = new List<int>(nums);
            list.Sort();
            for (int i = 0; i < list.Count() - 2;)
            {
                int j = i + 1;
                int k = list.Count() - 1;
                while (j < k)
                {
                    int sum = list[i] + list[j] + list[k];
                    if (sum == 0)
                        result.Add(new List<int>() { list[i], list[j], list[k] });
                
                    if (sum <= 0)
                        while (list[j] == list[++j] && j < k)
                        {
                        }
                    if (sum >= 0)
                        while (list[k] == list[--k] && j < k)
                        {
                        }
                }
                while (list[i] == list[++i] && i < list.Count() - 2)
                {
                }
            }

            return result;
        }

        bool CheckRepeat(string str)
        {
            if (str.Length % 2 == 0)
            {
                int length = str.Length;
                string left = str.Substring(0, length / 2);
                string right = str.Substring(length / 2, length / 2);

                bool different = false;
                for (int i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[i])
                    {
                        different = true;
                    }
                }

                if (!different)
                {
                    return true;
                }
            }

            return false;
        }

        public string FractionToDecimal(long numerator, long denominator)
        {
            StringBuilder sb = new StringBuilder();

            if (numerator > int.MaxValue || numerator <= int.MinValue)
            {
                if (numerator == int.MinValue && denominator == -1)
                    return (-numerator).ToString();
                return "";
            }

            long rigidnum = numerator / denominator;
            sb.Append(rigidnum);
            long leftnum = numerator - rigidnum * denominator;

            if (leftnum != 0)
            {
                sb.Append(".");

                StringBuilder smallpart = new StringBuilder();
                do
                {
                    numerator = leftnum * 10;
                    rigidnum = numerator / denominator;
                    leftnum = numerator - rigidnum * denominator;

                    // check 0
                    if (leftnum == 0)
                    {
                        break;
                    }
                    else
                    {
                        string str = smallpart.ToString();
                        if (CheckRepeat(str))
                        {
                            string left = str.Substring(0, str.Length);
                            str = "(" + left + ")";

                            smallpart.Clear();
                            smallpart.Append(str);
                            break;
                        }
                        else
                        {
                            smallpart.Append(rigidnum);
                        }
                    }
                }
                while(smallpart.Length <= 8);

                sb.Append(smallpart);
            }
            
            return sb.ToString();
        }

        int FindEnter(string str)
        {
            return str.IndexOf("\n");
        }

        bool HasLevel(string str)
        {
            return str.IndexOf("\t") != -1;
        }

        int GetAndClearLevel(ref string str)
        {
            int level = 1;
            while (HasLevel(str))
            {
                level++;
                str = str.Substring(1, str.Length - 1);
            }

//        if (str[0].ToString() == " ")
//        {
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (str[i].ToString() != " ")
//                {
//                    str = str.Substring(i, str.Length - i);
//                    break;
//                }
//            }   
//        }
            return level;
        }

        bool IsFile(string str)
        {
            return str.Contains(".");
        }

        public int LengthLongestPath(string input)
        {
            // 0. check validation
            if (!input.Contains("."))
                return 0;

            // 1.
            List<string> namelist = new List<string>();
            while (FindEnter(input) != -1)
            {
                int index = FindEnter(input);
                string str = input.Substring(0, index);
                input = input.Substring(index + 1, input.Length - index - 1);
                namelist.Add(str);
            }
            namelist.Add(input);

            // 2. 
            List<int> pathlengths = new List<int>();
            int pathlength = 0;
            Stack<string> dirstack = new Stack<string>();
            for (int i = 0; i < namelist.Count(); i++)
            {
                string path = namelist[i];
                int level = GetAndClearLevel(ref path);

                if (dirstack.Count < level)
                {
                    dirstack.Push(path);
                    pathlength += path.Length;
                }
                else if (dirstack.Count == level)
                {
                    string popstr = dirstack.Pop();
                    pathlength -= popstr.Length;

                    dirstack.Push(path);
                    pathlength += path.Length;
                }
                else // count > level
                {
                    do
                    {
                        string popstr = dirstack.Pop();
                        pathlength -= popstr.Length;
                    }
                    while(dirstack.Count >= level && dirstack.Count > 0);

                    dirstack.Push(path);
                    pathlength += path.Length;
                }

                if (IsFile(path))
                {
                    pathlengths.Add(pathlength + dirstack.Count() - 1);
                }
            }

            // 3. 
            int maxlength = int.MinValue;
            for (int i = 0; i < pathlengths.Count(); i++)
            {
                if (maxlength < pathlengths[i])
                {
                    maxlength = pathlengths[i];
                }
            }

            return maxlength;
        }

        bool IsAlreadyInLists(List<List<int>> lists, List<int> onelist)
        {
            if (lists.Count() == 0)
                return false;

            foreach (List<int> one in lists)
            {
                if (one[0] == onelist[0] && one[1] == onelist[1] && one[2] == onelist[2] && one[3] == onelist[3])
                    return true;
            }
            return false;
        }

        bool IsAlreadyInLists(IList<IList<int>> lists, List<int> onelist)
        {
            if (lists.Count() == 0)
                return false;

            foreach (List<int> one in lists)
            {
                if (one[0] == onelist[0] && one[1] == onelist[1] && one[2] == onelist[2] && one[3] == onelist[3])
                    return true;
            }
            return false;
        }

        bool HasTwoInLists(IList<IList<int>> lists, List<int> onelist)
        {
            if (lists.Count() == 0)
                return false;

            int num = 0;
            foreach (List<int> one in lists)
            {
                if (one[0] == onelist[0] && one[1] == onelist[1] && one[2] == onelist[2] && one[3] == onelist[3])
                    num++;
            }

            if (num >= 2)
                return true;
            return false;
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            // 0. sort newnums
            List<int> newnums = new List<int>(nums);
            newnums.Sort();

            // 1. memorise first 2 numbers' possible sum to a dictionary
            Dictionary<int, List<List<int>>> map = new Dictionary<int, List<List<int>>>();
            for (int i = 0; i < newnums.Count(); i++)
            {
                for (int j = 0; j != i && j < newnums.Count(); j++)
                {
                    int key = newnums[i] + newnums[j];
                    List<int> one = new List<int>(){ i, j };

                    if (map.Keys.Contains(key))
                    {
                        if (!IsAlreadyInLists(map[key], one))
                        {
                            map[key].Add(one);
                        }
                    }
                    else
                    {
                        List<List<int>> value = new List<List<int>>();
                        value.Add(one);
                        map.Add(key, value);
                    }
                }
            }

            // 2. go through dictionary with 2 pointers to left 2
            IList<IList<int>> results = new List<IList<int>>();
            foreach (KeyValuePair<int, List<List<int>>> item in map)
            {
                List<List<int>> value = item.Value;
                int left = 0;
                int right = newnums.Count() - 1;

                while (left < right)
                {
                    int sum = item.Key + newnums[left] + newnums[right];

                    if (sum == target)
                    {
                        // find a combination

                        foreach (List<int> one in value)
                        {
                            if (one.Contains(left) || one.Contains(right))
                            {
                                continue;
                            }
                            List<int> result = new List<int>(){ one[0], one[1], left, right };
                            result.Sort();
                            if (IsAlreadyInLists(results, result))
                            {
                                continue;
                            }
                            results.Add(result);
                        }
                    }

                    if (sum <= target)
                    {
                        while (newnums[left] == newnums[++left] && left < right)
                        {
                        }
                    }

                    if (sum >= target)
                    {
                        while (newnums[right] == newnums[--right] && left < right)
                        {
                        }
                    }
                }
            }

            // 3. 
            for (int i = results.Count() - 1; i >= 0; i--)
            {
                for (int j = 0; j < results[i].Count(); j++)
                {
                    results[i][j] = newnums[results[i][j]];
                }
            }

            // 4.
            for (int i = results.Count() - 1; i >= 0; i--)
            {
                List<int> templist = new List<int>(results[i]);
                if (HasTwoInLists(results, templist))
                {
                    results.RemoveAt(i);
                }
            }
            return results;
        }
    }

    public class Program
    {
        //        public static void Main()
        //        {
        //            Solution solution = new Solution();
        //
        //            {
        //                //int[] nums = { 1, 0, -1, 0, -2, 2 };
        //                int[] nums = { -3, -2, -1, 0, 0, 1, 2, 3 };
        //                //IList<IList<int>> matrix = solution.ThreeSum_Slow(nums);
        //                IList<IList<int>> matrix = solution.FourSum(nums, 0);
        //                for (int i = 0; i < matrix.Count(); i++)
        //                {
        //                    Console.WriteLine();
        //                    IList<int> list = matrix[i];
        //                    for (int j = 0; j < list.Count(); j++)
        //                    {
        //                        Console.Write(list[j] + "  ");
        //                    }
        //                    Console.WriteLine();
        //                }
        //            }
        //
        //            {
        //                //string str = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
        //                //string str2 = "a";
        //                //string str2 = "   dir\n\t  a.txt";
        //                //string str2 = "file name with  space.txt";
        //                string str2 = "a\n\tb.txt\na2\n\tb2.txt";
        //                Console.WriteLine(solution.LengthLongestPath(str2));
        //            }
        //
        //            {
        //                int n = 1;
        //                int d = 333;
        //                Console.WriteLine(solution.FractionToDecimal(n, d));
        //
        //            }
        //
        //            {
        //                int[] nums = { -1, 0, 1, 2, -1, -4 };
        //                //IList<IList<int>> matrix = solution.ThreeSum_Slow(nums);
        //                IList<IList<int>> matrix = solution.ThreeSum(nums);
        //                for (int i = 0; i < matrix.Count(); i++)
        //                {
        //                    Console.WriteLine();
        //                    IList<int> list = matrix[i];
        //                    for (int j = 0; j < list.Count(); j++)
        //                    {
        //                        Console.Write(list[j] + "  ");
        //                    }
        //                    Console.WriteLine();
        //                }
        //            }
        //
        //            {
        //                int[] nums = { 0, 2, -7, 11, -15, 0 };
        //                int[] arr = solution.TwoSum(nums, 0);
        //                for (int i = 0; i < arr.Length; i++)
        //                {
        //                    Console.Write(arr[i] + "  ");
        //                }
        //
        //                string str = "babababbabbbabbbbaaaaabbbaabbababa";
        //                Console.WriteLine(solution.FrequencySort(str));
        //            }
        //        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;

namespace SkillsSandbox
{
    //    public class ListNode
    //    {
    //        public int val;
    //        public ListNode next;
    //
    //        public ListNode(int x)
    //        {
    //            val = x;
    //        }
    //    }
    //
    public class LeetCode1111
    {
        public string Convert(string s, int numRows)
        {
            /*
            The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

            P   A   H   N
            A P L S I I G
            Y   I   R
            
            And then read line by line: "PAHNAPLSIIGYIR"
            Write the code that will take a string and make this conversion given a number of rows:

            string convert(string text, int nRows);
            convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".
         */

            return "";
        }

        public bool IsPowerOfTwo(int n)
        {
            /*  Given an integer, write a function to determine if it is a power of two. */
            return n > 0 & (n & --n) == 0;
        }

        public int HammingWeight(uint n)
        {
            /*
                Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

                For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
             */
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                count += ((n & 1) == 1) ? 1 : 0;
                n >>= 1;
            }
            return count;
        }

        public uint reverseBits(uint n)
        {
            /*
                Reverse bits of a given 32 bits unsigned integer.

                For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).

                Follow up:
                If this function is called many times, how would you optimize it?

                Related problem: Reverse Integer
            */

            uint result = 0;
            for (uint i = 0; i < 32; i++)
            {
                result <<= 1;
                result += n & 1;
                n >>= 1;
            }
            return result;
        }

        public int SingleNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                nums[i + 1] ^= nums[i];
            }
            return nums[nums.Length - 1];
        }

        public int LongestPalindrome(string s)
        {
            if (s.Length == 0)
                return 0;
            
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            bool hasSingle = false;
            int count = 0;
            foreach (KeyValuePair<char,int> one in map)
            {
                count += one.Value / 2;
                if (!hasSingle && one.Value % 2 == 1)
                {
                    hasSingle = true;
                }
            }
            return count * 2 + (hasSingle ? 1 : 0);
        }

        bool IsBadVersion(int version)
        {
            if (version > -1)
                return true;
            else
                return false;
        }

        int BSHelper(int left, int mid, int right)
        {
            if (left + 1 == right)
            {
                return right;
            }

            if (IsBadVersion(mid))
            {
                int newMid = (left + mid) / 2;
                return BSHelper(left, newMid, mid);
            }
            else
            {
                int newMid = (mid + right) / 2;
                return BSHelper(mid, newMid, right);
            }
        }

        public int FirstBadVersion(int n)
        {
            if (IsBadVersion(0))
                return 0;
    
            int left = 0;
            int mid = n / 2;
            int right = n - 1;
    
            int result = BSHelper(left, mid, right);
            return result;
        }

        public int FirstBadVersion2(int n)
        {
            int left = 0;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }


        int guess(int num)
        {
            if (num > theAnswerNum)
                return -1;
            else if (num < theAnswerNum)
                return 1;
            else
                return 0;
        }

        const int theAnswerNum = 6;

        int guessHelper(int left, int right)
        {
            int mid = (left + right) / 2;

            if (left < right)
            {
                if (guess(mid) > 0)
                {
                    return guessHelper(mid, right);
                }
                else if (guess(mid) < 0)
                {
                    return guessHelper(left, mid);
                }
                else
                {
                    return mid;
                }
            }
            else
                return -1;
        }

        int guessNumber(int n)
        {
            int left = 0; 
            int right = n;

            return guessHelper(left, right);    
        }

        int find(int[] nums, bool leftMost, int left, int right, int target)
        {
            if (left > right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            if (nums[mid] > target)
            {
                return find(nums, leftMost, left, mid - 1, target);
            }
            else if (nums[mid] < target)
            {
                return find(nums, leftMost, mid + 1, right, target);
            }
            else
            {
                if (leftMost && (mid > 0 && nums[mid - 1] == target))
                {
                    return find(nums, leftMost, left, mid - 1, target);
                }
                else if (!leftMost && (mid < nums.Length - 1 && nums[mid + 1] == target))
                {
                    return find(nums, leftMost, mid + 1, right, target);
                }
                else
                {
                    return mid;
                }
            }
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[]{ find(nums, true, 0, nums.Length - 1, target), find(nums, false, 0, nums.Length - 1, target) };
            return result;
        }

        static void PrintRange(int[] range)
        {
            Console.WriteLine(range[0]);
            Console.WriteLine(range[1]);
            Console.WriteLine();
        }

        long findSeed(int num, long left, long right)
        {
            if (left + 1 >= right)
                return -1;
            
            long mid = (left + right) / 2;

            if (mid * mid > num)
                return findSeed(num, left, mid);
            else if (mid * mid < num)
                return findSeed(num, mid, right);
            else
                return mid;
        }

        public bool IsPerfectSquare(int num)
        {
            if (num == 1)
                return true;
            return (findSeed(num, 1, num) >= 0);
        }

        void RemoveElement(List<int> list, int left, int right)
        {
            for (int i = right; i >= left; i--)
            {
                list.RemoveAt(i);
            }
        }

        public int RemoveDuplicates(ref int[] nums)
        {
            List<int> list = new List<int>(nums);
            int right = nums.Length - 1;
            int left = right - 1;

            while (left >= 0)
            {
                if (list[left] == list[right])
                {
                    if (left != 0)
                    {
                        left--;
                    }
                    else
                    {
                        RemoveElement(list, 1, right);
                        break;
                    }
                }
                else
                {
                    if (left + 1 == right)
                    {
                        left--;
                        right--;
                    }
                    else if (left + 1 < right)
                    {
                        RemoveElement(list, left + 2, right);
                        right = left + 1;
                    }
                    else
                    {
                        throw new ArgumentException("left shouldn't be equal or bigger to right");
                    }
                }
            }

            nums = list.ToArray();
            return nums.Length;
        }

        void RemoveDuplicatesAndPrintNums(ref int[] nums)
        {
            Console.WriteLine(RemoveDuplicates(ref nums));
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + "  ");
            }
            Console.WriteLine("\n");
        }

        public int RemoveDuplicates2(ref int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int iTo = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    continue;
                }
                else
                {
                    // You can uncomment out lines below to improve performance
                    //  if (iTo != i)
                    // {
                    nums[iTo] = nums[i];
                    //  }
                    iTo++;
                }
            }

            return iTo;
        }

        int searchHelper(int[] nums, int left, int right, int target)
        {
            if (left > right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            if (nums[mid] < target)
            {
                return searchHelper(nums, mid + 1, right, target);
            }
            else if (nums[mid] > target)
            {
                return searchHelper(nums, left, mid - 1, target);
            }
            else
            {
                return mid;
            }
        }

        int binarySearch(int[] nums, int start, int target)
        {
            return searchHelper(nums, start, nums.Length - 1, target);
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            if (numbers.Length < 2)
            {
                return result;
            }
            else if (numbers.Length == 2)
            {
                if (numbers[0] + numbers[1] == target)
                {
                    result[0] = 1;
                    result[1] = 2;
                    return result;
                }
                else
                {
                    return result;
                }
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    if (numbers[i] * 2 == target)
                    {
                        result[0] = i;
                        result[1] = i + 1;
                        return result;
                    }
                }
                else
                {
                    int left = numbers[i - 1];
                    int leftPairNum = target - left;
                    int secondIndex = binarySearch(numbers, i, leftPairNum);
                    if (secondIndex != -1)
                    {
                        result[0] = i;
                        result[1] = secondIndex + 1;
                        break;
                    }   
                }
            }

            return result;
        }

        void PrintResult(int[] result)
        {
            if (result[0] == 0)
            {
                Console.WriteLine("cannot find\n");
                return;
            }
            
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + "  ");
            }
            Console.WriteLine("\n");
        }

        public bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char one in s)
            {
                if (map.ContainsKey(one))
                {
                    map[one]++;
                }
                else
                {
                    map.Add(one, 1);
                }
            }

            foreach (char one in t)
            {
                if (map.ContainsKey(one))
                {
                    map[one]--;
                }
                else
                {
                    return false;
                }
            }

            foreach (KeyValuePair<char,int> pair in map)
            {
                if (pair.Value != 0)
                    return false;
            }
            return true;
        }

        public int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (map.ContainsKey(c))
                {
                    maxLength = maxLength > map.Count ? maxLength : map.Count;
                    if (map[c] + map.Count == i)
                        map[c] = i;
                    else
                    {
                        i = map[c];
                        map.Clear();
                    }
                }
                else
                {
                    map.Add(c, i);
                }
            }
            maxLength = maxLength > map.Count ? maxLength : map.Count;

            return maxLength;
        }

        bool isSubSet(string mother, StringBuilder queue)
        {
            for (int i = 0; i < queue.Length; i++)
            {
                if (mother[i] != queue[i])
                    return false;
            }
            return true;
        }

        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;

            if (haystack.Length == 0)
                return -1;
            
            StringBuilder queue = new StringBuilder();
            int length = needle.Length;

            for (int i = 0; i < haystack.Length; i++)
            {
                char c = haystack[i];
                if (c == needle[queue.Length])
                {
                    queue.Append(c);

                    if (queue.Length == length)
                    {
                        return i - length + 1;
                    }
                }
                else
                {
                    if (queue.Length != 0)
                    {
                        i -= queue.Length;
                        queue.Clear();
                    }
                }
            }

            return -1;
        }

        public int StrStr2(string haystack, string needle)
        {
            if (haystack == null || needle == null || needle.Length > haystack.Length)
                return -1;

            if (needle.Length == 0)
                return 0;
            
            int max = haystack.Length - needle.Length;

            for (int i = 0; i <= max; i++)
            {
                // find first character
                int indexOne = -1;
                for (indexOne = i; indexOne <= max; indexOne++)
                {
                    if (haystack[indexOne] == needle[0])
                        break;
                }

                // find rest character 
                if (indexOne <= max)
                {
                    // check whether they are the same
                    int j = indexOne;
                    int k = 0;
                    for (; k < needle.Length; j++, k++)
                    {
                        if (haystack[j] != needle[k])
                            break;
                    }

                    if (k == needle.Length)
                    {
                        return indexOne;
                    }
                }
                else
                {
                    break;
                }
            }

            return -1;
        }

        bool binaryCheckValid(string str)
        {



            return true;
        }

        public int MyAtoi(string str)
        {
            // 0. check no empty
            if (str.Length == 0)
            {
                return 0;
            }

            // 1. check no non-number, except -
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (c == '-' && i != 0)
                    return 0;

                if (!char.IsNumber(c) && c != '-')
                    return 0;
                //throw new ArgumentException("has letter");
            }

            // 2. check no 0 in front
            bool negative = str[0] == '-' ? true : false;
            if (negative)
                str = str.Substring(1, str.Length - 1);

            if (str[0] == '0')
                return 0;//throw new ArgumentException("has 0 in front");

            // 3. check > - int.min  and < int.max
            if (negative)
            {
                string strmin = int.MinValue.ToString();
                strmin = strmin.Substring(1, strmin.Length - 1);
                if (str.Length > strmin.Length)
                    return 0;
                    //throw new ArgumentException("out of range");
                else if (str.Length == strmin.Length)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] > strmin[i])
                            return 0;//throw new ArgumentException("out of range");
                    }
                }
            }
            else
            {
                string strmax = int.MinValue.ToString();
                if (str.Length > strmax.Length)
                    return 0;//throw new ArgumentException("out of range");
                else if (str.Length == strmax.Length)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] > strmax[i])
                            return 0;//throw new ArgumentException("out of range");
                    }
                }
            }

            // 4. calculate
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result += (int)(char.GetNumericValue(str[i])) * (int)(Math.Pow(10, str.Length - 1 - i));
            }
            return negative ? -result : result;
        }

        int FindFirstNotOf(string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != c)
                    return i;                   
            }
            return -1;
        }

        public int MyAtoi2(string str)
        {
            if (str.Length == 0 || FindFirstNotOf(str, ' ') == -1)
                return 0;
            
            long result = 0; 
            int sign = 1;

            int i = FindFirstNotOf(str, ' ');

            if (!(str[i] == '+' || str[i] == '-' || ('0' <= str[i] && str[i] <= '9')))
            {
                return 0;
            }

            sign = str[i] == '-' ? -1 : 1;
            i = str[i] == '-' || str[i] == '+' ? i + 1 : i;

            for (; i < str.Length && '0' <= str[i] && str[i] <= '9'; i++)
            {
                result = result * 10 + (str[i] - '0');

                if (result * sign > int.MaxValue)
                    return int.MaxValue;
                if (result * sign < int.MinValue)
                    return int.MinValue;   
            }   

            return (int)(result * sign);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            if (l1.val < l2.val)
            {
                ListNode t1 = l1;

                while (t1 != null && t1.next != null && t1.next.val < l2.val)
                {
                    t1 = t1.next;
                }

                t1.next = MergeTwoLists(t1.next, l2);
                return l1;
            }
            else
            {
                ListNode t2 = l2;

                while (t2 != null && t2.next != null && t2.next.val < l1.val)
                {
                    t2 = t2.next;
                }

                t2.next = MergeTwoLists(l1, t2.next);
                return l2;
            }
        }

        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(int.MinValue);
            ListNode tail = dummy;

            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    tail.next = l2;
                    break;
                }
                else if (l2 == null)
                {
                    tail.next = l1;
                    break;
                }
                else
                {
                    if (l1.val < l2.val)
                    {
                        tail.next = l1;
                        tail = tail.next;
                        l1 = l1.next;
                    }
                    else
                    {
                        tail.next = l2;
                        tail = tail.next;
                        l2 = l2.next;
                    }
                }
            }

            return dummy.next;
        }


        //        public static void Main()
        //        {
        //            LeetCode1111 lc = new LeetCode1111();

        //            {
        //                Console.WriteLine(lc.MyAtoi2(""));
        //                Console.WriteLine(lc.MyAtoi2("12s"));
        //                Console.WriteLine(lc.MyAtoi2("s12"));
        //                Console.WriteLine(lc.MyAtoi2("0001"));
        //                Console.WriteLine(lc.MyAtoi2("-1 2"));
        //                Console.WriteLine(lc.MyAtoi2("1-2"));
        //                Console.WriteLine(lc.MyAtoi2("888888888888"));
        //                Console.WriteLine(lc.MyAtoi2("-888888888888888"));
        //                Console.WriteLine(lc.MyAtoi2("-888888"));
        //                Console.WriteLine(lc.MyAtoi2("888888"));
        //            }

        //            {
        //                Console.WriteLine(lc.StrStr("", ""));
        //                Console.WriteLine(lc.StrStr("1", "1"));
        //                Console.WriteLine(lc.StrStr("abcdedf", "cde"));
        //                Console.WriteLine(lc.StrStr("abcabcf", "abc"));
        //                Console.WriteLine(lc.StrStr("mississippi", "issip"));
        //                Console.WriteLine(lc.StrStr("mississippi", "pi"));
        //                Console.WriteLine(lc.StrStr("ababcaababcaabc", "ababcaabc"));
        //
        //                Console.WriteLine(lc.StrStr2("", ""));
        //                Console.WriteLine(lc.StrStr2("1", "1"));
        //                Console.WriteLine(lc.StrStr2("abcdedf", "cde"));
        //                Console.WriteLine(lc.StrStr2("abcabcf", "abc"));
        //                Console.WriteLine(lc.StrStr2("mississippi", "issip"));
        //                Console.WriteLine(lc.StrStr2("mississippi", "pi"));
        //                Console.WriteLine(lc.StrStr2("ababcaababcaabc", "ababcaabc"));
        //            }

        //            {
        //                Console.WriteLine(lc.LengthOfLongestSubstring("pwwkew"));
        //                Console.WriteLine(lc.LengthOfLongestSubstring("p"));
        //                Console.WriteLine(lc.LengthOfLongestSubstring(""));
        //                Console.WriteLine(lc.LengthOfLongestSubstring("dvdf"));
        //                Console.WriteLine(lc.LengthOfLongestSubstring("abcabced"));
        //                Console.WriteLine(lc.LengthOfLongestSubstring("ohvhjdml"));
        //            }

        //            {
        //                Console.WriteLine(lc.IsAnagram("abcde", "ebcda"));
        //                Console.WriteLine(lc.IsAnagram("abcde", "ebcd2"));
        //            }

        //            {
        //                int[] nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                int[] result = lc.TwoSum(nums, 0);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 1);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 2);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 3);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 4);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 6);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 8);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7 };
        //                result = lc.TwoSum(nums, 20);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ };
        //                result = lc.TwoSum(nums, 20);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 4, 2 };
        //                result = lc.TwoSum(nums, 5);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 4, 2 };
        //                result = lc.TwoSum(nums, 6);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 1, 3, -2, 4 };
        //                result = lc.TwoSum(nums, 2);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 2, 2, 2, 4, 5 };
        //                result = lc.TwoSum(nums, 9);
        //                lc.PrintResult(result);
        //
        //                nums = new int[]{ 2, 2, 2, 4, 5 };
        //                result = lc.TwoSum(nums, 4);
        //                lc.PrintResult(result);
        //            }

        //            {
        //                int[] nums = new int[]{ 1, 2, 2, 3, 3, 3, 4 };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //
        //                nums = new int[]{ 1 };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //
        //                nums = new int[]{ 1, 1, 2 };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //
        //                nums = new int[]{ };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //
        //                nums = new int[]{ int.MaxValue };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //
        //                nums = new int[]{ int.MinValue, 0, int.MaxValue };
        //                lc.RemoveDuplicatesAndPrintNums(ref nums);
        //            }
        //
        //            {
        //                Console.WriteLine(lc.IsPerfectSquare(16).ToString());
        //                Console.WriteLine(lc.IsPerfectSquare(14).ToString());
        //                Console.WriteLine(lc.IsPerfectSquare(1).ToString());
        //                Console.WriteLine(lc.IsPerfectSquare(0).ToString());
        //                Console.WriteLine(lc.IsPerfectSquare(int.MaxValue).ToString());
        //            }

        //            {
        //                int[] nums = new int[]{ 0, 2, 2, 4 };
        //                PrintRange(lc.SearchRange(nums, -1));
        //                PrintRange(lc.SearchRange(nums, 0));
        //                PrintRange(lc.SearchRange(nums, 1));
        //                PrintRange(lc.SearchRange(nums, 2));
        //                PrintRange(lc.SearchRange(nums, 3));
        //                PrintRange(lc.SearchRange(nums, 4));
        //                PrintRange(lc.SearchRange(nums, 5));
        //
        //                nums = new int[]{ 1 };
        //                PrintRange(lc.SearchRange(nums, 0));
        //                PrintRange(lc.SearchRange(nums, 1));
        //
        //                nums = new int[]{ 2, 2 };
        //                PrintRange(lc.SearchRange(nums, 2));
        //            }

        //            {
        //                Console.WriteLine(lc.guessNumber(10));
        //            }

        //            {
        //                Console.WriteLine(lc.FirstBadVersion(6));
        //                Console.WriteLine(lc.FirstBadVersion(5));
        //                Console.WriteLine(lc.FirstBadVersion(1));
        //            }
        //
        //            {
        //                string result = lc.Convert("PAYPALISHIRING", 3);
        //                Console.WriteLine(result);
        //            }
        //
        //            {
        //                string s = "bb";
        //                Console.WriteLine(lc.LongestPalindrome(s));
        //            }
        //
        //            {
        //                int[] nums = new int[]{ 2, 3, 2, 4, 5, 4, 3  };
        //                Console.WriteLine(lc.SingleNumber(nums));
        //            }
        //
        //            {
        //                Console.WriteLine(lc.reverseBits(9999));
        //                Console.WriteLine(lc.reverseBits(4041474048));
        //            }
        //
        //            {
        //                Console.WriteLine(lc.HammingWeight(9999));
        //                Console.WriteLine(lc.HammingWeight(63));
        //            }
        //
        //            {
        //                Console.WriteLine(lc.IsPowerOfTwo(1));
        //                Console.WriteLine(lc.IsPowerOfTwo(64));
        //                Console.WriteLine(lc.IsPowerOfTwo(63));
        //                Console.WriteLine(lc.IsPowerOfTwo(2));
        //                Console.WriteLine(lc.IsPowerOfTwo(int.MaxValue));
        //            }
        //        }
    }
}


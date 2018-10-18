using System;
using System.Collections.Generic;


namespace algorithm
{
    public class SortingClass
    {
        public static string AlphabetSoup(string str)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                numbers.Add(str[i]);
            }

            numbers.Sort();

            string newStr = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                newStr += Char.ConvertFromUtf32(numbers[i]);
            }

            return newStr;
        }

        public static string ABCheck(string str)
        {
            List<int> anums = new List<int>();
            List<int> bnums = new List<int>();

            // 1.
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    anums.Add(i);
                    Console.WriteLine("a add " + i);
                }
                if (str[i] == 'b')
                {
                    bnums.Add(i);
                    Console.WriteLine("b add " + i);
                }
            }

            // 2.
            foreach (int a in anums)
            {
                foreach (int b in bnums)
                {
                    if (a - 4 == b || a + 4 == b)
                    {
                        return "true";
                    }
                }
            }

            return "false";
        }

        public static int VowelCount(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    count++;
                }
            }
            return count;
        }

        public static int WordCount(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == ' ')
                {
                    count++;
                }
            }
            return count + 1;
        }

        public static string ExOh(string str)
        {
            int onum = 0;
            int xnum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'o')
                {
                    onum++;
                }
                else
                {
                    xnum++;
                }
            }
            if (onum == xnum)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static string Palindrome(string str)
        {
            int length = str.Length;
            int halfLength = 0;

            string left = "";
            string middle = "";
            string right = "";

            if (length % 2 == 0)
            {
                halfLength = length / 2;
                left = str.Substring(0, length / 2);
                right = str.Substring(length / 2, length / 2);

            }
            else
            {
                halfLength = (length - 1) / 2;
                left = str.Substring(0, (length - 1) / 2);
                middle = Convert.ToString(str[(length - 1) / 2]);
                right = str.Substring((length - 1) / 2 + 1, (length - 1) / 2);
            }
            Console.WriteLine("l: " + left + " m: " + middle + " r: " + right);
            for (int i = 0; i < halfLength; i++)
            {
                if (left[i] != right[halfLength - 1 - i])
                {
                    return "false";
                }
            }

            return "true";
        }

        public static string ArithGeo(int[] arr)
        {
            // 1. diff
            List<int> diff = new List<int>();
            for (int i = 1; i < arr.Length; i++)
            {
                diff.Add(arr[i] - arr[i - 1]);
            }

            // 2. div
            List<int> div = new List<int>();
            for (int i = 1; i < diff.Count; i++)
            {
                div.Add(diff[i] / diff[i - 1]);
            }

            // 3. check
            int x = div[0];
            for (int i = 1; i < div.Count; i++)
            {
                if (x != div[i])
                {
                    return "-1";
                }
            }

            // 4. return
            if (x == 1)
            {
                return "Arithmetic";
            }
            else
            {
                return "Geometric";
            }
        }

        static List<int> GetPossibleValue(List<int> rawList)
        {
            List<int> possibleList = new List<int>();

            if (rawList.Count == 1)
            {
                possibleList.Add(rawList[0]);
                possibleList.Add(0);
            }
            else
            {
                for (int i = 0; i < rawList.Count; i++)
                {
                    List<int> newRawList = new List<int>(rawList);
                    newRawList.RemoveAt(i);

                    List<int> newPossibleList = GetPossibleValue(newRawList);
                    for (int j = 0; j < newPossibleList.Count; j++)
                    {
                        int possibleValue = rawList[i] + newPossibleList[j];
                        if (!possibleList.Contains(possibleValue))
                        {
                            possibleList.Add(possibleValue);
                        }
                    }
                }
            }

            return possibleList;
        }

        public static string ArrayAdditionI(int[] arr)
        {
            List<int> allValues = new List<int>(arr);
            allValues.Sort();
            int max = allValues[allValues.Count - 1];
            allValues.RemoveAt(allValues.Count - 1);

            List<int> possibleValues = GetPossibleValue(allValues);

            foreach (int one in possibleValues)
            {
                Console.WriteLine(one);
            }

            int length = possibleValues.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(possibleValues[i]);
                if (possibleValues[i] == max)
                {
                    return "true";
                }
            }
            return "false";
        }

        static int GetRepeatNum(string str)
        {
            Dictionary<char, int> repeatdic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (repeatdic.ContainsKey(c))
                {
                    repeatdic[c]++;
                }
                else
                {
                    repeatdic.Add(c, 1);
                }
            }

            int max = 0;
            foreach (KeyValuePair<char, int> entry in repeatdic)
            {
                int value = entry.Value;
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }

        public static string LetterCountI(string str)
        {
            // 1. divide to string array
            List<string> words = new List<string>();
            int left = 0;
            int right = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    string word = "";
                    if (i == str.Length - 1)
                    {
                        word = str.Substring(left, right - left + 1);
                    }
                    else
                    {
                        word = str.Substring(left, right - left);
                    }
                    words.Add(word);
                    //Console.WriteLine(word);
                    right = right + 1;
                    left = right;
                }
                else
                {
                    right++;
                }
            }

            // 2. count repeat to int array
            List<int> nums = new List<int>();
            for (int i = 0; i < words.Count; i++)
            {
                nums.Add(GetRepeatNum(words[i]));
            }

            // 3. get max number
            int index = 0;
            int max = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    index = i;
                }
            }

            // 4. return
            if (max == 1)
            {
                return "-1";
            }
            else
            {
                return words[index];
            }
        }

        public static string SecondGreatLow(int[] arr)
        {
            List<int> nums = new List<int>(arr);
            nums.Sort();

            int secondLow = 0;
            int secondGreat = 0;
            if (nums.Count == 2)
            {
                secondLow = nums[0];
                secondGreat = nums[1];
            }
            else
            {
                int min = nums[0];
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] > min)
                    {
                        secondLow = nums[i];
                        break;
                    }
                }
                   
                int max = nums[nums.Count - 1];
                for (int i = nums.Count - 1; i >= 0; i--)
                {
                    if (nums[i] < max)
                    {
                        secondGreat = nums[i];
                        break;
                    }
                }
            }

            return secondGreat + " " + secondLow;
        }

        public static string DivisionStringified(int num1, int num2)
        {
            double x = (double)num1 / (double)num2;
            string s = x.ToString("0.00");
            string[] parts = s.Split('.'); 
            int left = int.Parse(parts[0]);
            int right = int.Parse(parts[1]);

            if (right >= 50)
                left++;

            List<string> combine = new List<string>();
            string leftstr = Convert.ToString(left);
            int length = leftstr.Length;
            string final = "";

            if (length <= 3)
            {
                final = leftstr;
            }
            else
            {
                int i = 0;
                for (i = length - 3; i > 0; i -= 3)
                {
                    string word = leftstr.Substring(i, 3);
                    combine.Add(word);
                    combine.Add(",");
                }
                i += 3;
                combine.Add(leftstr.Substring(0, i));

                for (i = combine.Count - 1; i >= 0; i--)
                {
                    final += combine[i];
                }
            }
           
            return final;
        }
    }
}

using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace algorithm
{
    public class TimeMinDiff
    {
        public static int TimeMinDifference(string[] strArr)
        {
            // 1.
            List<int> timeArr = GetTimeArr(strArr);

            // 2.
            timeArr.Sort();

            // 3. 
            List<int> diffArr = new List<int>();
            for (int i = 0; i < timeArr.Count - 1; i++)
            {
                diffArr.Add(timeArr[i + 1] - timeArr[i]);
                Debug.Assert(timeArr[i + 1] - timeArr[i] >= 0);
            }
            diffArr.Add((timeArr[0] - 0) + (24 * 60 - timeArr[timeArr.Count - 1]));

            // 4.
            int minDiff = diffArr[0];
            foreach (int x in diffArr)
            {
                if (x < minDiff)
                {
                    minDiff = x;
                }
            }

            return minDiff;
        }

        static List<int> GetTimeArr(string[] strArr)
        {
            List<int> valueArray = new List<int>();

            foreach (string one in strArr)
            {
                bool isAm = one.Contains("am");
                int hour12 = isAm ? 0 : 12 * 60;

                string valueStr = one.TrimEnd('m');
                valueStr = valueStr.TrimEnd('p');
                valueStr = valueStr.TrimEnd('a');

                string[] value = valueStr.Split(':');
                int h, m;
                int.TryParse(value[0], out h);
                int.TryParse(value[1], out m);
                Console.WriteLine("h = " + h + " m = " + m + " value 1 = " + value[1]);

                h = (h == 12) ? 0 : h;

                int totalMin = hour12 + h * 60 + m;
                valueArray.Add(totalMin);

                Console.WriteLine(totalMin);
            }

            return valueArray;
        }
    }

    public class LongestWordClass
    {
        public static string LongestWord(string sen)
        {
            int left = 0;
            int right = 0;
            List<string> words = new List<string>();

            for (int i = 0; i < sen.Length; i++)
            {
                char c = sen[right];
                if (!char.IsLetterOrDigit(c) || i == sen.Length - 1)
                {
                    string word = "";
                    if (i == sen.Length - 1)
                    {
                        char lastOne = sen[sen.Length - 1];
                        if (char.IsLetterOrDigit(lastOne))
                        {
                            word = sen.Substring(left, right - left + 1);
                        }
                        else
                        {
                            word = sen.Substring(left, right - left);
                        }
                    }
                    else
                    {
                        word = sen.Substring(left, right - left);
                    }

                    if (word != "")
                    {
                        words.Add(word);
                        //Console.WriteLine(word);
                    }   


                    left = right + 1;
                    right = right + 1;
                }
                else
                {
                    right++;
                }
            }

            int maxIndex = 0;
            int maxLength = words[0].Length;

            for (int i = 1; i < words.Count; i++)
            {
                string one = words[i];
                if (one.Length > maxLength)
                {
                    maxLength = one.Length;
                    maxIndex = i;
                }
            }

            return words[maxIndex];
        }
    }

    public class PalindromicClass
    {
        //        static string AddOneAt(string str, int index)
        //        {
        //        }

        public static int NextPalindrome(int num)
        {
            string numStr = Convert.ToString(num);
            int length = numStr.Length;

            if (length == 1)
            {
                if (Convert.ToInt32(numStr) < 9)
                {
                    return num + 1;
                }
                else
                {
                    return 11;
                }
            }

            string leftStr = "";
            string rightStr = "";
            string totalStr = "";
            string middleV = "";

            if (length % 2 == 1)
            {
                // has top e.g. 123
                leftStr = numStr.Substring(0, length / 2);
                middleV = Convert.ToString(numStr[length / 2]);
                rightStr = numStr.Substring(length / 2 + 1, length / 2);
            }
            else
            {
                leftStr = numStr.Substring(0, length / 2);
                rightStr = numStr.Substring(length / 2, length / 2);
            }

            //Console.WriteLine("Split " + numStr + " to leftStr = " + leftStr + " middleStr = " + middleV + "  rightStr = " + rightStr);

            int halfLength = leftStr.Length;

            // compare value
            for (int i = halfLength - 1; i >= 0; i--)
            {
                bool encounter10 = false;

                if (encounter10)
                {
                    string x1 = leftStr.Substring(0, i);
                    string leftV = Convert.ToString(leftStr[i]);
                    {
                        int v = Convert.ToInt32(leftV);
                        v++;
                        if (v == 10)
                        {
                            encounter10 = true;
                            v = 0;
                        }
                        else
                        {
                            encounter10 = false;
                        }
                        leftV = Convert.ToString(v);
                    }
                    string x2 = leftStr.Substring(i + 1, halfLength - 1 - i);

                    Console.WriteLine("x1 = " + x1 + " leftV = " + leftV + " x2 = " + x2);

                    leftStr = x1 + leftV + x2;

                    break;   
                }

                if (Convert.ToInt32(leftStr[i]) <= Convert.ToInt32(rightStr[halfLength - 1 - i]))
                {
                    //Console.WriteLine("left V = " + leftStr[i] + " right V = " + rightStr[halfLength - 1 - i]);

                    if (middleV != "" && i == halfLength - 1)
                    {
                        int v = Convert.ToInt32(middleV);
                        v++;
                        if (v == 10)
                        {
                            encounter10 = true;
                            v = 0;
                        }
                        middleV = Convert.ToString(v);
                        break;
                    }
                    else
                    {
                        string x1 = leftStr.Substring(0, i);
                        string leftV = Convert.ToString(leftStr[i]);
                        {
                            int v = Convert.ToInt32(leftV);
                            v++;
                            if (v == 10)
                            {
                                encounter10 = true;
                                v = 0;

                            }
                            leftV = Convert.ToString(v);
                        }
                        string x2 = leftStr.Substring(i + 1, halfLength - 1 - i);

                        Console.WriteLine("x1 = " + x1 + " leftV = " + leftV + " x2 = " + x2);

                        leftStr = x1 + leftV + x2;
                        break;   
                    }
                }
                Console.WriteLine("leftC = " + leftStr[i] + "rightC = " + rightStr[halfLength - 1 - i]);
            }

            // change rightStr
            rightStr = "";
            for (int i = 0; i < halfLength; i++)
            {
                rightStr += leftStr[halfLength - 1 - i];
            }

            // get total
            totalStr = leftStr + middleV + rightStr;
            Console.WriteLine("totalStr = " + totalStr);

            return Convert.ToInt32(totalStr);
        }
    }

}


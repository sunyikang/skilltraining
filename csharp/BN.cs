using System;

namespace SkillsSandbox
{
    public class BN
    {
        private long GetSum(int[] arr, int left, int right)
        {
            if ((left < 0 || left > arr.Length - 1) || (right < 0 || right > arr.Length - 1))
            {
                throw new ArgumentOutOfRangeException("GetSum");
            }

            long sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public long GetMaxSum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;
            
            int left = 0;
            long maxsum = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                long sum = 0;
                for (int j = left; j <= i; j++)
                {
                    sum += arr[j];
                }

                if (sum > maxsum)
                    maxsum = sum;
                else
                {
                    if (left != i)
                    {
                        for (int k = left; k <= i; k++)
                        {
                            long tempsum = GetSum(arr, left, k);
                            if (tempsum >= 0 || k == i)
                            {
                                left = k;

                                if (k == i)
                                    i--;

                                break;
                            }
                        }   
                    }
                }
            }
            return maxsum;
        }
    }

    public class BN1109
    {
        //        public static void Main()
        //        {
        //            BN one = new BN();
        //
        //            {
        //                int[] arr = new int[]{ -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //
        //            {
        //                int[] arr = new int[]{ 23, 1, -3, 2, -11 };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //
        //            {
        //                int[] arr = new int[]{ -1, -1, -2, -1, -1 };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //
        //            {
        //                int[] arr = new int[]{ -1, -1, -2, 1, -1 };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //
        //            {
        //                int[] arr = new int[]{ };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //
        //            {
        //                int[] arr = new int[]{ int.MaxValue - 1, int.MaxValue - 1  };
        //                Console.WriteLine(one.GetMaxSum(arr));
        //            }
        //        }
    }
}


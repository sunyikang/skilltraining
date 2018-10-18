using System;

namespace SkillsSandbox
{
    public class ListNode
    {
        public int val;
        public ListNode next = null;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            ListNode result = new ListNode(0);
            ListNode resulttemp = result;
            ListNode t1 = l1;
            ListNode t2 = l2;

            int addup = 0;
            while (t1 != null || t2 != null || addup != 0)
            {
                int v1 = (t1 == null) ? 0 : t1.val;
                int v2 = (t2 == null) ? 0 : t2.val;

                int sum = v1 + v2 + addup; 
                if (sum > 9)
                {
                    sum = sum - 10;
                    addup = 1;
                }
                else
                {
                    addup = 0;
                }

                resulttemp.val = sum;
                if ((t1 != null && t1.next != null) || (t2 != null && t2.next != null) || addup != 0)
                {
                    resulttemp.next = new ListNode(0);
                    resulttemp = resulttemp.next;   
                }
                    
                if (t1 != null)
                    t1 = t1.next; 
                
                if (t2 != null)
                    t2 = t2.next;
            }
            resulttemp = null;

            return result;
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (lower <= nums[i] && nums[i] <= upper)
                {
                    count++;
                }
            }

            return (count + 1) * count / 2;
        }

        public int GetSumOfLeft(TreeNode node, bool isleft)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null && isleft)
                    return node.val;

                return GetSumOfLeft(node.left, true) + GetSumOfLeft(node.right, false);   
            }
            return 0;
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            return GetSumOfLeft(root, false);
        }
    }

    //    public class LeetCode1107
    //    {
    //        public static void Main()
    //        {
    //            Solution solution = new Solution();
    //
    //            {
    //                ListNode l1 = new ListNode(2);
    //                l1.next = new ListNode(4);
    //                l1.next.next = new ListNode(3);
    //
    //                ListNode l2 = new ListNode(5);
    //                l2.next = new ListNode(6);
    //                l2.next.next = new ListNode(4);
    //
    //                //ListNode l3 = solution.AddTwoNumbers(l1, l2);
    //                ListNode l3 = solution.AddTwoNumbers(null, null);
    //                for (ListNode temp = l3; temp != null; temp = temp.next)
    //                {
    //                    Console.Write(temp.val.ToString() + " ");
    //                }
    //            }
    //
    //            {
    //                int[] nums = new int[]{ -2, 5, 1 };
    //                int result = solution.CountRangeSum(nums, -2, 2);
    //                Console.WriteLine(result);
    //            }
    //
    //            {
    //                TreeNode root = new TreeNode(3);
    //                root.left = new TreeNode(9);
    //                root.right = new TreeNode(20);
    //                root.right.left = new TreeNode(15);
    //                root.right.right = new TreeNode(7);
    //                Console.WriteLine(solution.SumOfLeftLeaves(root));
    //            }
    //        }
    //    }
}


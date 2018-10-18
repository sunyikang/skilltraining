using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;



namespace SkillsSandbox
{
    public class MyStack
    {
        Queue<int> q = new Queue<int>();

        // Push element x onto stack.
        public void Push(int x)
        {
            q.Enqueue(x);
            for (int i = 0; i < q.Count - 1; i++)
                q.Enqueue(q.Dequeue());
        }

        // Removes the element on top of the stack.
        public void Pop()
        {
            q.Dequeue();
        }

        // Get the top element.
        public int Top()
        {
            return q.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty()
        {
            return q.Count != 0;
        }
    }

    public struct Vector2
    {
        // public Vector2()
        // {
        //     this.x = 0;
        //     this.y = 0;
        // }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public long x;
        public long y;
    }

    public class LeetCode1121
    {
        bool IsValidLeft(char left, char right)
        {
            if ((left == '(' || left == '[' || left == '{') && (right == '(' || right == '[' || right == '{'))
                return true;
            return false;
        }

        bool IsValidPair(char left, char right)
        {
            if (left == '(' && right == ')' || left == '[' && right == ']' || left == '{' && right == '}')
                return true;
            return false;
        }

        public bool IsValid(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length - 1;)
            {
                char left = sb[i];
                char right = sb[i + 1];

                if (IsValidLeft(left, right))
                {
                    i++;
                }
                else
                {
                    if (IsValidPair(left, right))
                    {
                        sb.Remove(i, 2);
                        i = (i == 0) ? 0 : i - 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return sb.Length == 0;
        }

        void Helper(Dictionary<int, IList<TreeNode>> map, int level)
        {
            IList<TreeNode> children = new List<TreeNode>();
            IList<TreeNode> treeList = map[level];
            for (int i = 0; i < treeList.Count; i++)
            {
                TreeNode node = treeList[i];
                if (node.left != null)
                    children.Add(node.left);
                if (node.right != null)
                    children.Add(node.right);
            }

            if (children.Count > 0)
            {
                map.Add(level + 1, children);
                Helper(map, level + 1);
            }
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            Dictionary<int, IList<TreeNode>> map = new Dictionary<int, IList<TreeNode>>();
            IList<TreeNode> rootList = new List<TreeNode>();
            rootList.Add(root);
            map.Add(0, rootList);
            Helper(map, 0);

            for (int i = 0; i < map.Count; i++)
            {
                IList<TreeNode> nodelist = new List<TreeNode>();
                nodelist = map[i];
                IList<int> nodevaluelist = new List<int>();

                for (int j = 0; j < nodelist.Count; j++)
                {
                    nodevaluelist.Add(nodelist[j].val);
                }

                result.Add(nodevaluelist);
            }

            return result;
        }

        bool AddNewVectors(HashSet<Vector2> map, long length, ref int direction, ref Vector2 start)
        {
            Vector2 newvector = start;
            long offsetx = (long)(Math.Cos(direction * Math.PI / 180));
            long offsety = (long)(Math.Sin(direction * Math.PI / 180));

            int i = 0;
            do
            {
                newvector.x += offsetx;
                newvector.y += offsety;

                if (map.Contains(newvector))
                    return true;
                else
                    map.Add(newvector);

                i++;
            }
            while (i < length);

            start = newvector;
            direction = (direction == 270) ? 0 : direction + 90;

            return false;
        }

        public bool IsSelfCrossing(int[] x)
        {
            HashSet<Vector2> map = new HashSet<Vector2>();

            Vector2 startpoint = new Vector2(0, 0);
            int direction = 90;

            map.Add(new Vector2(0, 0));
            for (int i = 0; i < x.Length; i++)
            {
                if (AddNewVectors(map, (long)x[i], ref direction, ref startpoint))
                    return true;
            }

            return false;
        }

        public bool IsSelfCrossing2(int[] x)
        {
            if (x.Length <= 3)
                return false;

            if (x[0] < x[2])
            {
                for (int i = 1; i < x.Length - 2; i++)
                {
                    if (x[i] >= x[i + 2])
                        return true;
                }
            }
            else
            {
                for (int i = 1; i < x.Length - 2; i++)
                {
                    if (x[i] <= x[i + 2])
                        return true;
                }
            }
            return false;
        }

        void InitMap(Dictionary<char, List<int>> map, Dictionary<int, char> map2, string str)
        {
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char one = str[i];
                if (map.ContainsKey(one))
                {
                    map[one].Add(i);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    map.Add(one, list);

                    map2.Add(index, one);
                    index++;
                }
            }
        }

        public bool IsIsomorphic(string s, string t)
        {
            if (s == "" && t == "")
                return true;

            if (s.Length != t.Length)
                return false;

            int l = s.Length;

            Dictionary<char, List<int>> maps = new Dictionary<char, List<int>>();
            Dictionary<int, char> maps2 = new Dictionary<int, char>();

            Dictionary<char, List<int>> mapt = new Dictionary<char, List<int>>();
            Dictionary<int, char> mapt2 = new Dictionary<int, char>();

            InitMap(maps, maps2, s);
            InitMap(mapt, mapt2, t);

            int i = 0;
            while (maps2.ContainsKey(i) && maps.ContainsKey(maps2[i]) && mapt2.ContainsKey(i) && mapt.ContainsKey(mapt2[i]))
            {
                List<int> lists = maps[maps2[i]];
                List<int> listt = mapt[mapt2[i]];

                if (lists.Count != listt.Count)
                    return false;

                for (int j = 0; j < lists.Count; j++)
                {
                    if (lists[j] != listt[j])
                        return false;
                }

                i++;
            }

            return true;
        }

        public int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 0)
            {
                throw new ArgumentException("");
            }

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string str = tokens[i];

                bool isnum = true;
                int num = 0;
                char c = ' ';
                if (str.Length > 1)
                {
                    if (!Int32.TryParse(str, out num))
                    {
                        throw new ArgumentException("cannot parse str to num");
                    }
                }
                else
                {
                    c = str[0];
                    if (char.IsNumber(c))
                    {
                        num = Convert.ToInt32(str);
                    }
                    else if (c == '*' || c == '/' || c == '+' || c == '-')
                    {
                        isnum = false;
                    }
                    else
                    {
                        throw new ArgumentException("operator is wrong");
                    }
                }

                if (isnum)
                {
                    nums.Push(num);
                }
                else
                {
                    if (nums.Count < 2)
                        throw new ArgumentOutOfRangeException("");

                    int right = nums.Pop();
                    int left = nums.Pop();
                    if (c == '*')
                    {
                        nums.Push(left * right);
                    }
                    else if (c == '/')
                    {
                        nums.Push(left / right);
                    }
                    else if (c == '+')
                    {
                        nums.Push(left + right);
                    }
                    else if (c == '-')
                    {
                        nums.Push(left - right);
                    }
                    else
                    {
                        // error
                    }
                }
            }

            if (nums.Count != 1)
                throw new ArgumentOutOfRangeException("return is error");

            return nums.Pop();
        }

        public int[,] GenerateMatrix(int n)
        {
            if (n < 1)
                return null;

            int[,] matrix = new int[n, n];
            int total = (int)(Math.Pow(n, 2));

            int x = 0;
            int y = 0;
            int up = 1;
            int bottom = n;
            int left = 0;
            int right = n;

            int index = 1;
            int offsetx = 0;
            int offsety = 1;
            do
            {
                matrix[x, y] = index++;

                x += offsetx;
                y += offsety;

                if (offsetx == 0 && offsety == 1 && y + 1 == right)
                {
                    offsetx = 1;
                    offsety = 0;
                    right--;
                }
                else if (offsetx == 1 && offsety == 0 && x + 1 == bottom)
                {
                    offsetx = 0;
                    offsety = -1;
                    bottom--;
                }
                else if (offsetx == 0 && offsety == -1 && y == left)
                {
                    offsetx = -1;
                    offsety = 0;
                    left++;
                }
                else if (offsetx == -1 && offsety == 0 && x == up)
                {
                    offsetx = 0;
                    offsety = 1;
                    up++;
                }
                else
                {
                    // do nothing
                }
            }
            while (index <= total);

            return matrix;
        }

        int maximumGap(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)  //corner check
                return 0;
            int numsMin = nums[0];
            int numsMax = nums[0];

            //get the max value and the min value of the  array
            for (int i = 1; i < nums.Length; i++)
            {
                numsMin = Math.Min(numsMin, nums[i]);
                numsMax = Math.Max(numsMax, nums[i]);
            }

            // if all numbers of the array are equal, return 0 
            if (numsMin == numsMax)
                return 0;
            int len = nums.Length;
            int gap = (int)Math.Ceiling((numsMax - numsMin) * 1.0 / (len - 1));

            // store the min value in that bucket
            // store the max value in that bucket
            int[] bucketMin = new int[len];
            int[] bucketMax = new int[len];
            for (int i = 0; i < bucketMin.Length; i++)
            {
                bucketMin[i] = int.MaxValue;
                bucketMax[i] = int.MinValue;
            }

            for (int i = 0; i < len; i++)         //scan the array
            {
                int idx = (nums[i] - numsMin) / gap;
                bucketMin[idx] = Math.Min(nums[i], bucketMin[idx]);
                bucketMax[idx] = Math.Max(nums[i], bucketMax[idx]);
            }

            for (int i = 0; i < len; i++)
            {
                //judge if the bucket is empty
                if (bucketMin[i] != int.MaxValue)
                {
                    //update the max gap
                    gap = Math.Max(bucketMin[i] - numsMin, gap);
                    numsMin = bucketMax[i];
                }
            }

            return gap;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;

            if (m == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    nums1[i] = nums2[i];
                }
                return;
            }

            // 1. move right n
            for (int i = m - 1; i >= 0; i--)
            {
                nums1[i + n] = nums1[i];
            }

            // 2. compair and insert
            int id = 0;
            int id1 = n;
            int id2 = 0;

            do
            {
                int n1 = nums1[id1];
                int n2 = nums2[id2];

                if (n1 < n2)
                {
                    nums1[id] = nums1[id1];
                    id1++;
                }
                else
                {
                    nums1[id] = nums2[id2];
                    id2++;
                }
                id++;
            }
            while (id1 < n + m && id2 < n);

            if (id1 == n + m)
            {
                for (int i = id; i < n + m; i++)
                {
                    nums1[id++] = nums2[id2++];
                }
            }
        }

        int Parse(string str)
        {
            Stack<int> stack = new Stack<int>();

            char previous = str[0];
            for (int i = 1; i < str.Length; i++)
            {
                char current = str[i];
            }

            return 0;
        }

        void Helper(StringBuilder sb, int index, int maxIndex, IList<string> result, int target, IList<string> operations, string num)
        {
            if (index <= maxIndex)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    // append operations
                    sb.Append(operations[i]);

                    // append number
                    sb.Append(num[index]);

                    // go to next index
                    Helper(sb, index + 1, maxIndex, result, target, operations, num);

                    // recover
                    sb.Remove(sb.Length - 2 - operations[i].Length, operations[i].Length + 1);
                }
            }
            else
            {
                // means that it have gone to the end
                if (Parse(sb.ToString()) == target)
                {
                    result.Add(sb.ToString());
                }
            }
        }

        public IList<string> AddOperator(string num, int target)
        {
            // TODO:  check scope ..


            IList<string> result = new List<string>();

            StringBuilder sb = new StringBuilder();
            sb.Append(num[0]);

            IList<string> operations = new List<string>();
            operations.Add("+");
            operations.Add("-");
            operations.Add("*");
            operations.Add("");

            Helper(sb, 1, num.Length - 1, result, target, operations, num);

            return result;
        }


        // public static void Main()
        // {
        //     LeetCode1121 lc = new LeetCode1121();

        //     {
        //         IList<string> result = lc.AddOperator("4320", 40);
        //         foreach (string one in result)
        //         {
        //             Console.WriteLine(one);
        //         }
        //     }

            // {
            //     int[] nums1 = new int[]{ 1, 2, 4, 5, 6, 0 };
            //     int[] nums2 = new int[]{ 3 };
            //     lc.Merge(nums1, 5, nums2, 1);                    
            // }

            // {
            //     int[] nums1 = new int[]{ 1, 2, 4, 5, 6, 0 };
            //     int[] nums2 = new int[]{ 8 };
            //     lc.Merge(nums1, 5, nums2, 1);                    
            // }

            //
            //            {
            //                int[] aaa = new int[]{ 2, 5, 1, 20, 3 };
            //                lc.maximumGap(aaa);
            //            }
            //
            //            {
            //                lc.GenerateMatrix(1);
            //            }
            //            {
            //                string[] tokens = new string[]{ "3", "-4", "+" };
            //                Console.WriteLine(lc.EvalRPN(tokens));
            //            }

            //            {
            //                string[] tokens = new string[]{ "2", "1", "-", "*" };
            //                Console.WriteLine(lc.EvalRPN(tokens));
            //            }

            //
            //            {
            //                lc.IsIsomorphic("aabbd", "cceed");
            //            }

            //            {
            //                int[] x = { 1, 2, 3, 4 };
            //                Console.WriteLine(lc.IsSelfCrossing2(x).ToString());
            //            }
            //
            //            {
            //                int[] x = { 1, 1, 1, 1 };
            //                Console.WriteLine(lc.IsSelfCrossing2(x).ToString());
            //            }
            //
            //            {
            //                int[] x = { 2, 1, 1, 2 };
            //                Console.WriteLine(lc.IsSelfCrossing2(x).ToString());
            //            }
            //
            //            {
            //                int[] x = { };
            //                Console.WriteLine(lc.IsSelfCrossing2(x).ToString());
            //            }
            //
            //            {
            //                int[] x = { 3, 3, 4, 2, 2 };
            //                Console.WriteLine(lc.IsSelfCrossing2(x).ToString());
            //            }

            //            {
            //                int[] x = { int.MaxValue, int.MaxValue };
            //                Console.WriteLine(lc.IsSelfCrossing(x).ToString());
            //            }

            //            {
            //                Console.WriteLine(lc.IsValid("[[](()){}"));
            //                Console.WriteLine(lc.IsValid("[[(])(()){}"));
            //                Console.WriteLine(lc.IsValid("[[]](()){}"));
            //            }
            //
            //            {
            ////                TreeNode node = new TreeNode(9);
            ////                node.left = new TreeNode(2);
            ////                node.right = new TreeNode(3);
            ////                lc.LevelOrder(node);
            //
            //                lc.LevelOrder(null);
            //
            //            }
        //}
    }
}


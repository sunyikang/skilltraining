using System;
using System.Text;
using System.Collections.Generic;

namespace VacationCoding
{
    // TODO : 1. shortcut to clean up the code
    public class UndirectedGraphNode {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class Solution 
    {
        public IList<int> LexicalOrder(int n) 
        {
            IList<int> result = new List<int>();

            int curr = 1;
            for(int i = 1; i <= n; i++)
            {
                result.Add(curr);

                if(curr * 10 <= n)
                {
                    // 1 --> 10 --> 100
                    curr = curr * 10;
                }
                else if(curr % 10 != 9 && curr + 1 <= n)
                { 
                    // 18 --> 19
                    curr++;
                }
                else
                {
                    // 199 --> 19
                    while((curr / 10) % 10 == 9)
                    {
                        curr /= 10;
                    }

                    // 19 --> 2
                    curr = curr / 10 + 1;
                }
            }

            return result;
        }

        public string PrintGraph(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> map = null)
        {
            string result = string.Empty;
            {
                if(map == null)
                {
                    map = new Dictionary<int, UndirectedGraphNode>();
                }

                if(!map.ContainsKey(node.label))
                {
                    result = node.label.ToString();
                    map.Add(node.label, node);

                    foreach(UndirectedGraphNode one in node.neighbors)
                    {
                        result += ", " + one.label.ToString();
                    }
                    result += "#";
                                    
                    foreach(UndirectedGraphNode one in node.neighbors)
                    {
                        result += PrintGraph(one, map);
                    }
                }
            }
            return result;
        }

        public void CloneGraph(UndirectedGraphNode oldNode, UndirectedGraphNode newNode, Dictionary<int, UndirectedGraphNode> map)
        {
            if(map.ContainsKey(newNode.label))
                return;

            map.Add(newNode.label, newNode);
            foreach(UndirectedGraphNode neighbor in oldNode.neighbors)
            {
                UndirectedGraphNode newNeighbor = new UndirectedGraphNode(neighbor.label);
                newNode.neighbors.Add(newNeighbor);
                CloneGraph(neighbor, newNeighbor, map);
            }
        } 

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) 
        {
            if(node == null) return null;

            UndirectedGraphNode newNode = new UndirectedGraphNode(node.label);
            Dictionary<int, UndirectedGraphNode> map = new Dictionary<int, UndirectedGraphNode>();
            CloneGraph(node, newNode, map);           
            return newNode;
        }

        public static void Main()
        {
            Solution solution = new Solution();

            // lexical order
            {
                IList<int> result = solution.LexicalOrder(10);
                StringBuilder sb = new StringBuilder();
                foreach(int x in result)
                {
                    sb.Append(x);
                    sb.Append(", ");
                }
                Console.WriteLine(sb.ToString());
            }

            // clone graph
            {
                UndirectedGraphNode nodeZero = new UndirectedGraphNode(0);
                UndirectedGraphNode nodeOne = new UndirectedGraphNode(1);
                UndirectedGraphNode nodeTwo = new UndirectedGraphNode(2);

                nodeZero.neighbors.Add(nodeOne);
                nodeZero.neighbors.Add(nodeTwo);
                nodeOne.neighbors.Add(nodeTwo);
                nodeTwo.neighbors.Add(nodeTwo);

                Console.WriteLine($"\noriginal is : {solution.PrintGraph(nodeZero)}\n");
                UndirectedGraphNode newNode = solution.CloneGraph(nodeZero);
                Console.WriteLine($"\nnew node is : {solution.PrintGraph(newNode)}\n");
            }
        }
    }
}
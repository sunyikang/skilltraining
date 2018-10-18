using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace DirectedGraph
{
    // Topological Sort Graph Algorithm: https://www.youtube.com/watch?v=ddTC4Zovtbc

    public class Graph
    {
        private int V;
        private List<int>[] map = null;

        public Graph(int v)
        {
            this.V = v;

            map = new List<int>[V];
            for (int i = 0; i < v; i++)
            {
                map[i] = new List<int>();
            }
        }

        public void AddEdges(int start, int end)
        {
            if (start < 0 || start >= this.V)
            {
                throw new ArgumentOutOfRangeException("start");
            }

            if (end < 0 || end >= this.V)
            {
                throw new ArgumentOutOfRangeException("end");
            }

            map[start].Add(end);
        }

        bool CheckCicle(bool[] visited, bool[] tempvisited, int node)
        {
            visited[node] = true;
            tempvisited[node] = true;
            {
                List<int> children = map[node];
                foreach (int child in children)
                {
                    if (tempvisited[child])
                        return true;

                    if (!visited[child])
                    {
                        if (CheckCicle(visited, tempvisited, child))
                            return true;
                    }
                }
            }                
            tempvisited[node] = false;
            return false;
        }

        public bool IsThereACicle()
        {
            bool[] visited = new bool[V];
            bool[] tempvisited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    if (CheckCicle(visited, tempvisited, i))
                        return true;
                }
            }

            return false;
        }

        void Helper(bool[] visited, Stack<int> stack, int node)
        {
            visited[node] = true;
            {
                List<int> children = map[node];
                foreach (int child in children)
                {
                    if (!visited[child])
                    {
                        Helper(visited, stack, child);
                    }
                }
            }
            stack.Push(node);
        }

        public int[] TopologicalSort()
        {
            if (this.map == null || !map.Any())
            {
                throw new InvalidOperationException("invalid map");
            }

            bool[] visited = new bool[V];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    Helper(visited, stack, i);
                }
            }

            return stack.ToArray();
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Solution
    {
        bool TopSortUntil(Dictionary<int, List<int>> map, List<int> visited, List<int> tmpvisited, Stack<int> stack, int node)
        {
            visited.Add(node);
            tmpvisited.Add(node);

            if (map.Keys.Contains(node))
            {
                List<int> children = map[node];
                foreach (int one in children)
                {
                    if (tmpvisited.Contains(one))
                        return false; 
                    
                    if (!visited.Contains(one))
                    {
                        if (!TopSortUntil(map, visited, tmpvisited, stack, one))
                            return false;   
                    }
                }
            }

            tmpvisited.Remove(node);            
            stack.Push(node); 
            return true;
        }

        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            int[] emptyarr = new int[]{ };

            // 1. to dictionary
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int key = prerequisites[i, 1];
                int value = prerequisites[i, 0];

                if (map.Keys.Contains(key))
                {
                    map[key].Add(value);
                }
                else
                {
                    List<int> values = new List<int>();
                    values.Add(value);
                    map.Add(key, values);
                }
            }

            // visit and stack
            List<int> visited = new List<int>();
            List<int> tmpvisited = new List<int>();
            Stack<int> stack = new Stack<int>();

            for (int num = 0; num < numCourses; num++)
            {
                if (!visited.Contains(num))
                {
                    tmpvisited.Clear();
                    if (!TopSortUntil(map, visited, tmpvisited, stack, num))
                    {
                        return emptyarr;
                    }   
                }
            }

            return stack.ToArray();
        }

        public int[] FindOrderViaGraph(int numCourses, int[,] prerequisites)
        {
            Graph g = new Graph(numCourses);

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                g.AddEdges(prerequisites[i, 1], prerequisites[i, 0]);
            }

            List<int> order = new List<int>();

            if (g.IsThereACicle())
            {
                return order.ToArray();
            }

            return g.TopologicalSort();
        }
    }


    //    public class Program
    //    {
    //        public static void PrintOrder(int numCourses, int[,] prerequisites)
    //        {
    //            Solution solution = new Solution();
    //            int[] result = solution.FindOrderViaGraph(numCourses, prerequisites);
    //            for (int i = 0; i < result.Length; i++)
    //            {
    //                Console.Write(result[i] + "  ");
    //            }
    //            Console.WriteLine("\n----\n");
    //        }
    //
    //        public static void Main()
    //        {
    //            PrintOrder(4, new int[,]{ { 1, 0 }, { 2, 0 }, { 3, 1 }, { 3, 2 } });
    //            PrintOrder(2, new int[,]{ });
    //            PrintOrder(3, new int[,]{ { 0, 1 }, { 0, 2 }, { 1, 2 } });
    //            PrintOrder(2, new int[,] { { 0, 1 }, { 1, 0 } });
    //
    //        }
    //    }
}


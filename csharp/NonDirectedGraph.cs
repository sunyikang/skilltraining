using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace NonDirectedGraph
{
    class Vertics : HashSet<int>
    {
    }

    class Edges : Dictionary<string, int>
    {
        public Edges GetNeighorEdgesOfVertex(int vertex)
        {
            Edges newedges = new Edges();

            foreach (KeyValuePair<string, int> one in this)
            {
                if (one.Key.Contains(vertex.ToString()))
                {
                    newedges.Add(one.Key, one.Value);
                }
            }

            return newedges;
        }
    }

    class KnownEdgeValue
    {
        public int weight;
        public bool visited;

        public KnownEdgeValue(int weight, bool visited)
        {
            this.weight = weight;
            this.visited = visited;
        }
    }

    class KnownEdges : Dictionary<string, KnownEdgeValue>
    {
        // all edges those are known by Tree
        // bool means whether a known edge is visited or not
    }

    class Tree
    {
        Vertics vertexs = new Vertics();

        public int VertexsCount
        {
            get
            {
                return vertexs.Count;
            }
        }

        KnownEdges knownedges = new KnownEdges();

        public bool ContainVertex(int v)
        {
            return vertexs.Contains(v);
        }

        public void AddNewVertex(int vertex, Edges newedges)
        {
            // add vertex
            Debug.Assert(!vertexs.Contains(vertex));
            vertexs.Add(vertex);

            // add vertex's all edges
            foreach (KeyValuePair<string, int> one in newedges)
            {
                if (!knownedges.ContainsKey(one.Key))
                {
                    KnownEdgeValue value = new KnownEdgeValue(one.Value, false);
                    knownedges.Add(one.Key, value);
                }
            }
        }

        public int VisitShortestVertexToTree()
        {
            // 1. find the edge and visit it
            int minWeight = int.MaxValue;
            string edge = "";
            foreach (KeyValuePair<string, KnownEdgeValue> one in knownedges)
            {
                if (minWeight > one.Value.weight && !one.Value.visited)
                {
                    minWeight = one.Value.weight;
                    edge = one.Key;
                }
            }

            knownedges[edge].visited = true;

            // 2. find the vertex and visit it
            for (int i = 0; i < edge.Length; i++)
            {
                char c = edge[i];
                int v = (int)char.GetNumericValue(c);
                if (!vertexs.Contains(v))
                {
                    return v;
                }
            }

            Debug.Assert(false, "shouldn't be here");
            return -1;
        }

        public string GetTreeEdges()
        {
            string edgestr = "";
            foreach (KeyValuePair<string, KnownEdgeValue> one in knownedges)
            {
                if (one.Value.visited)
                {
                    edgestr += one.Key + "->";
                }
            }
            return edgestr;
        }
    }

    public class VertexSet
    {
        public string name;
        string vertexstr = "";

        public void AddV(string v)
        {
            if (!vertexstr.Contains(v))
            {
                vertexstr += v;
                name = v;
            }
        }

        public bool ContainV(string v)
        {
            return vertexstr.Contains(v);
        }

        public void Union(VertexSet anotherset)
        {
            vertexstr += anotherset.vertexstr;
        }

        public string Find(string v)
        {
            if (vertexstr.Contains(v))
                return name;
            else
                return "";
        }
    }

    public class VertexSets : List<VertexSet>
    {
        public bool ContainV(string v)
        {
            foreach (VertexSet set in this)
            {
                if (set.ContainV(v))
                    return true;
            }
            return false;
        }

        public string FindSet(string v)
        {
            foreach (VertexSet set in this)
            {
                string result = set.Find(v);
                if (result != "")
                    return result;
            }
            return "";
        }

        public void Combine(string set1name, string set2name)
        {
            VertexSet set1 = null;
            VertexSet set2 = null;
            foreach (VertexSet set in this)
            {
                if (set1name == set.name)
                {
                    set1 = set;
                }
                if (set2name == set.name)
                {
                    set2 = set;
                }

                if (set1 != null && set2 != null)
                    break;
            }

            set1.Union(set2);
            this.Remove(set2);
        }
    }

    public class Graph
    {
        Vertics vertics;
        Edges edges;

        public Graph()
        {
            vertics = new Vertics();
            edges = new Edges();

            vertics.Add(1);
            vertics.Add(2);
            vertics.Add(3);
            vertics.Add(4);
            vertics.Add(5);
            vertics.Add(6);

            edges.Add("12", 2);
            edges.Add("13", 3);
            edges.Add("24", 3);
            edges.Add("23", 5);
            edges.Add("25", 4);
            edges.Add("35", 4);
            edges.Add("45", 2);
            edges.Add("46", 3);
            edges.Add("56", 5);
        }

        public string GetMinTreeSpanByPrimAlgorithm()
        {
            Tree tree = new Tree();
            tree.AddNewVertex(1, edges.GetNeighorEdgesOfVertex(1));

            do
            {
                int vertex = tree.VisitShortestVertexToTree();
                if (!tree.ContainVertex(vertex))
                {
                    tree.AddNewVertex(vertex, edges.GetNeighorEdgesOfVertex(vertex));
                }
            }
            while(tree.VertexsCount < vertics.Count);

            return tree.GetTreeEdges();
        }

        bool CheckCircle(Edges edges)
        {
            // YIKANG TODO: https://www.youtube.com/watch?v=n_t0a_8H8VY

            // 1. make set list
            VertexSets vertexSetList = new VertexSets();

            foreach (KeyValuePair<string, int> one in edges)
            {
                for (int i = 0; i < one.Key.Length; i++)
                {
                    char c = one.Key[i];

                    if (!vertexSetList.ContainV(c.ToString()))
                    {
                        VertexSet set = new VertexSet();
                        set.AddV(c.ToString());
                        vertexSetList.Add(set);
                    }
                }
            }

            // 2. go through detected edges, if can find 2 valid different sets, union them; else it is circle
            foreach (KeyValuePair<string, int> one in edges)
            {
                string v1 = one.Key[0].ToString();
                string set1 = vertexSetList.FindSet(v1);

                string v2 = one.Key[1].ToString();
                string set2 = vertexSetList.FindSet(v2);

                if (set1 == set2)
                {
                    return true;
                }
                else
                {
                    vertexSetList.Combine(set1, set2);
                }
            }
            return false;  
        }

        public string GetMinTreeSpanByKruskalAlgorithm()
        {
            Edges detectedEdges = new Edges();
            foreach (KeyValuePair<string,int> one in edges.OrderBy(key=> key.Value))
            { 
                string edge = one.Key;
                detectedEdges.Add(one.Key, one.Value);
                if (CheckCircle(detectedEdges))
                {
                    detectedEdges.Remove(one.Key);
                }
            }

            string str = "";
            foreach (KeyValuePair<string,int> one in detectedEdges)
            {
                str += one.Key + "->";
            }
            return str;
        }
    }

    public class Program
    {
        /*
        // public static void Main()
        // {
        //     Graph graph = new Graph();

        //     Console.WriteLine(graph.GetMinTreeSpanByPrimAlgorithm());

        //     Console.WriteLine(graph.GetMinTreeSpanByKruskalAlgorithm());
        // }
        */
    }
}


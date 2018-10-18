using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KPathfinding : MonoBehaviour
{
    public Transform seeker, target;
    Node start, end;
    Grid grid;

    void Start()
    {
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        start = grid.NodeFromWorldPoint(seeker.position);
        end = grid.NodeFromWorldPoint(target.position);
        FindPath();
    }

    void FindPath()
    {
        // build open list
        PrioQueue openList = new PrioQueue();

        // build close list
        HashSet<Node> closeList = new HashSet<Node>();

        // add start node to open
        openList.Enqueue(start);

        /*
        // loop
            // current node = a node in open with smallest cost
            // remove it from open
            // add it into close

            // if current node is target node return 

            // foreach neighbour of current node 
                // if neighbour is not traversable or neighbour is in close, skip to next neighbour

                // if new path to neighbour is shorter or neighbour is not in open
                    // set new cost to neighbour
                    // set parent of neighbour to current
                    // if neighbour is not in open, add it to open
        */

        while (!openList.IsEmpty())
        {
            Debug.Log(openList.Peek().gridX + " " + openList.Peek().gridY);

            Node current = openList.Dequeue();

            if (current == null)
                return;

            closeList.Add(current);

            if (current == end)
            {
                // calculate the path
                RetracePath(start, end);
                Debug.LogWarning(grid.path.Count);
                return;
            }

            List<Node> neighbours = grid.GetNeighbours(current);

            foreach (Node neighbour in neighbours)
            {
                if (!neighbour.walkable || closeList.Contains(neighbour))
                    continue;

                int newCostToNeighbour = current.gCost + GetDistance(current, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openList.Contain(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, end);
                    neighbour.parent = current;

                    if (!openList.Contain(neighbour))
                        openList.Enqueue(neighbour);
                }
            }
        }
    }


    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;

    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}

using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

public class PrioQueue
{
    List<Node> list = new List<Node>();

    public bool IsEmpty()
    {
        return list.Count == 0;
    }

    public Node Dequeue()
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            Node front = list[0];
            list.Remove(front);
            return front;
        }
    }

    public bool Contain(Node one)
    {
        return list.Contains(one);
    }

    public Node Peek()
    {
        if (IsEmpty())
            throw new Exception("Please check that priorityQueue is not empty before peeking");
        else
        {
            return list[0];
        }
    }

    public void Enqueue(Node item)
    {
        int cost = item.fCost;

        bool inserted = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (cost < list[i].fCost)
            {
                list.Insert(i, item);
                inserted = true;
                UnityEngine.Debug.Log(item.gridX + " " + item.gridY);
                break;
            }
        }

        if (!inserted)
            list.Add(item);
    }
}

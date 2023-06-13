using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public readonly bool Walkable;

    public Vector3 WorldPos;

    public readonly int GridX;
    public readonly int GridY;

    public int GCost;
    public int HCost;

    public Node Parent;

    public Node(bool walkable, Vector3 worldPos, int gridX, int gridY)
    {
        Walkable = walkable;
        WorldPos = worldPos;

        GridX = gridX;
        GridY = gridY;
    }

    public int FCost
    {
        get { return GCost + HCost; }
    }
}
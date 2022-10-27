using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    
    public bool allowedToWalk;
    public Vector3 worldPosition;

    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public Node(bool allowedToWalk, Vector3 worldPosition)
    {
        
        this.allowedToWalk = allowedToWalk;
        this.worldPosition = worldPosition;
        //this.gridX = gridX;
        //this.gridY = gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
        
    }
}

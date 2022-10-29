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
    public Node parent;
    public Node(bool allowedToWalk, Vector3 worldPosition, int gridX, int gridY)
    {
        
        this.allowedToWalk = allowedToWalk;
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public int fCost()
    {
        return gCost + hCost;
  
    }
}

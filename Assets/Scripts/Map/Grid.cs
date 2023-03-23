using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    //Variables for making the grid.
    [Header("Grid Variables")]
    public LayerMask notAllowedToWalk;
    public Vector2 gridSize;
    public float nodeSize;
    Node[,] grid;
    int gridSizeX, gridSizeY;
    
    [Header("Scripts")]
    PlayerMovement Player_Movement_Script;

    //Function: Start this 
    void Awake()
    {
        Player_Movement_Script = GameObject.FindObjectOfType<PlayerMovement>();
        gridSizeX = (int)(gridSize.x / (nodeSize * 2));
        gridSizeY = (int)(gridSize.x / (nodeSize * 2));
        GenerateMapGrid();
    }
    
     /*private void OnDrawGizmos()
     {
         Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, gridSize.y, 3));
         foreach (Node n in grid)
         {
             Node playerNode = GetNodePosition(Player_Movement_Script.GetPlayerPosition());

             Gizmos.color = (n.allowedToWalk) ? Color.white : Color.red;
             if (playerNode == n)
             {
                 Gizmos.color = Color.cyan;
             }
           
             Gizmos.DrawCube(n.worldPosition, Vector3.one * ((nodeSize * 2) - 0.1f));
         }
     }*/
    public Vector3 GetbottomLeft()
    {
        Vector3 bottomLeft = transform.position - Vector3.right * gridSize.x / 2 - Vector3.up * gridSize.y / 2;
        return bottomLeft;
    }

    public Vector3 Position(int x , int y)
    {
        Vector3 worldPosition = GetbottomLeft() + Vector3.right * (x * (nodeSize * 2) + nodeSize) + Vector3.up * (y *
                (nodeSize * 2 ) + nodeSize);

        return worldPosition;
    }

    public bool Walkable(int x, int y)
    {
        bool allowedToWalk;

        //Check if allowed to walk or not.
        if ((Physics2D.OverlapCircle(Position(x,y), (int)(nodeSize), notAllowedToWalk)) == false)
        {
            allowedToWalk = true;
        }
        else
        {
            allowedToWalk = false;
        }
        return allowedToWalk;
    }
    public void GenerateMapGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        
        for(int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {

                grid[x, y] = new Node(Walkable(x, y), Position(x, y),x,y);
            }
        }
    }
    public Node GetNodePosition(Vector3 position)
    {
        //Get the axis percent, along the grid.
        float percentX = (position.x + gridSize.x / 2) / gridSize.x;
        float percentY = (position.y + gridSize.y / 2) / gridSize.y;
       
        //avoiding errros in case the object is out of bounds.
        if(percentX < 0)
        {
            percentX = 0;
        }
        else if(percentX > 1){
            percentX = 1;
        }
        else if(percentY < 0)
        {
            percentY = 0;
        }
        else if (percentY > 1)
        {
            percentY = 1;
        }
        
        int x = (int)((gridSizeX) * percentX);
        int y = (int)((gridSizeY) * percentY);
        
        return grid[x, y];
    }
    
    public List<Node> FindNeighbours(Node neighbour)
    {
        int x_axis;
        int y_axis;
        List<Node> neighbours = new List<Node>();
        
        for (int x = -1; x<= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x==0 && y == 0)
                {
                    continue;
                }
                x_axis = neighbour.gridX + x;
                y_axis = neighbour.gridY + y;
                
                if(x_axis >= 0 && x_axis < gridSizeX && y_axis >= 0 && y_axis < gridSizeY)
                {
                    neighbours.Add(grid[x_axis, y_axis]);
                }
            }
        }
        return neighbours;
    }

    public int GetWidth()
    {
        return (int)(gridSize.x);
    }

    public int GetHeight()
    {
        return (int)(gridSize.y);
    }
}




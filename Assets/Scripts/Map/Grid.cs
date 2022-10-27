using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    [Header("Grid Variables")]
    public LayerMask notAllowedToWalk;
    public Vector2 gridSize;
    public float nodeSize;
    
    Node[,] grid;
    int gridSizeX, gridSizeY;
    PlayerMovement Player_Movement_Script;

    public void Start()
    {
        Player_Movement_Script = GameObject.FindObjectOfType<PlayerMovement>();
        gridSizeX = (int)(gridSize.x / (nodeSize * 2));
        gridSizeY = (int)(gridSize.x / (nodeSize * 2));
        GenerateMapGrid();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, gridSize.y, 3));
        foreach (Node n in grid)
        {
            Node playerNode = getPlayerPosition(Player_Movement_Script.GetPlayerPosition());
            
            Gizmos.color = (n.allowedToWalk) ? Color.white : Color.red;
            if (playerNode == n)
            {
                Gizmos.color = Color.cyan;
            }

            Gizmos.DrawCube(n.worldPosition, Vector3.one * ((nodeSize * 2) - 0.1f));
        }
    }
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

                grid[x, y] = new Node(Walkable(x, y), Position(x, y));
            }
        }
    }
    public Node getPlayerPosition(Vector3 position)
    {
        float percentX = (position.x + gridSize.x / 2) / gridSize.x;
        float percentY = (position.y + gridSize.y / 2) / gridSize.y;
        //avoiding errros in case the player is outside the grid
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = (int)((gridSizeX - 1) * percentX);
        int y = (int)((gridSizeY - 1) * percentY);
        return grid[x, y];
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFinding : MonoBehaviour
{
    MoveToTarget moveToTarget_Script;
    Grid grid_Script;
    
    public void Awake()
    {
        //Get the necessary scripts.
        grid_Script = GetComponent<Grid>();
        moveToTarget_Script = GetComponent<MoveToTarget>();
    }
    public void FindStartPath(Vector3 startPosition, Vector3 endPosition)
    {
        StartCoroutine(GetPath(startPosition, endPosition));
    }

    //A Ienumerator function that excutes A* algorithm.
    public IEnumerator GetPath(Vector3 startPosition, Vector3 endPosition)
    {
        Vector3[] points = new Vector3[0];
        bool pathSucess = false;
        //convert Vector3 into node positions.
        Node startNode = grid_Script.GetNodePosition(startPosition);
        Node endNode = grid_Script.GetNodePosition(endPosition);
        
        if(startNode.allowedToWalk && endNode.allowedToWalk)
        {
            //A* algorithm uses a openset and a closedset list
            List<Node> openList = new List<Node>();
            HashSet<Node> closedList = new HashSet<Node>();
            openList.Add(startNode);
            //Search when the openset has a bigger size than zero.
            while (openList.Count > 0)
            {
                //find the node in the openset with the lowest F cost.
                Node currentNode = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].fCost() < currentNode.fCost() || openList[i].fCost() == currentNode.fCost() && openList[i].hCost < currentNode.hCost)
                    {
                        currentNode = openList[i];
                    }
                }
                //Now we have the lowest f cost in the openset, remove it from the openset and add it to the closedset.
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == endNode)
                {
                    pathSucess = true;

                    break;
                }
                foreach (Node neighbour in grid_Script.FindNeighbours(currentNode))
                {
                    //If is in the closet set then skip ahead to the next neighbour.
                    if (!neighbour.allowedToWalk || closedList.Contains(neighbour))
                    {
                        continue;
                    }
                    
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openList.Contains(neighbour))
                    {
                        //Calculate hcost and gcost.
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, endNode);
                        neighbour.parent = currentNode;

                        if (!openList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                        }
                    }
                }
            }
        }
       
        yield return null;
        if (pathSucess)
        {
            points = RetracePath(startNode, endNode);
        }
        moveToTarget_Script.FinishedPath(points, pathSucess);
    }

    //To get the path we need to retrace it from the start node to the end node. tracing the path backwards.
    public Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] points = SimplifyPath(path);
        Array.Reverse(points);
        
        return points;


    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> points = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;
        for (int i = 1; i< path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if(directionNew != directionOld)
            {
                points.Add(path[i].worldPosition);

            }
            directionOld = directionNew;

        }
        return points.ToArray();
    }

    //Calculate the distance between the nodes. In A* a diagonal move costs 1.4 and horizontal costs 1, however multiply by 10 for simplicity.
    int GetDistance(Node NodeA, Node NodeB)
    {
        int distX = Mathf.Abs(NodeA.gridX - NodeB.gridX);
        int distY = Mathf.Abs(NodeA.gridY - NodeB.gridY);
        if(distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        return 14 * distX + 10 * (distY - distX);
    }

}

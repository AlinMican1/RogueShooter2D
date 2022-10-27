using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    /*Grid grid;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    private void FindingPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Nodes startNode = grid.NodefromWorldPoint(startPosition);
        Nodes targetNode = grid.NodefromWorldPoint(targetPosition);

        List<Nodes> openSet = new List<Nodes>();
        HashSet<Nodes> closedSet = new HashSet<Nodes>();
        openSet.Add(startNode);
        //stopped at 16:47
        while (openSet.Count > 0)
        {
            Nodes currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if ( openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost
                && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            if(currentNode == targetNode)
            {
                return;
            }
            foreach (Nodes neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.allowedToWalk || closedSet.Contains(neighbour))
                {
                    continue;
                }
            }
        }
    }

    int GetDistance(Nodes nodeA , Nodes nodeB)
    {
        int dstX = (int)(nodeA.gridX - nodeB.gridX);
        int dstY = (int)(nodeA.gridY - nodeB.gridY);
        if(dstX > dstY)
        {
            return 14 * dstY + 10 * (dstX - dstY);
        }
        return 14 * dstX + 10 * (dstY - dstX);
    }*/
}

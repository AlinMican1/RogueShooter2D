using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    float speed = 2;
    Vector3[] path;
    int targetIndex;

    private void Start()
    {

        MoveToTarget.RequestPath(transform.position, player.position, OnPathFound);


    }

    private void Update()
    {
       
        MoveToTarget.RequestPath(transform.position, player.position, OnPathFound);
      

    }

    public void OnPathFound(Vector3[] newPath, bool pathSucessful)
    {
        if (pathSucessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    IEnumerator FollowPath()
    {
        Vector3 currentPoint = path[0];

        while (true)
        {
            if(transform.position == currentPoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    targetIndex = 0;
                    path = new Vector3[0]; 
                    yield break;
                }
                currentPoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentPoint, speed * Time.deltaTime);
            yield return null;
        }
    }
}

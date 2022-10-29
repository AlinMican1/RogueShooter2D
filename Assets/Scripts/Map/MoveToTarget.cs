using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathRequest;
    bool processPath;
    static MoveToTarget instance;
    PathFinding pathfinding_script;

    public void Awake()
    {
        instance = this;
        pathfinding_script = GetComponent<PathFinding>();
    }
    
    public static void RequestPath(Vector3 startPath, Vector3 endPath, Action<Vector3[],bool> callback)
    {
        PathRequest newRequest = new PathRequest(startPath, endPath, callback);
        instance.pathRequestQueue.Enqueue(newRequest);
        instance.TryNext();
    }
    struct PathRequest
    {
        public Vector3 startPath;
        public Vector3 endPath;
        public Action<Vector3[], bool> callback;

        public PathRequest(Vector3 startPath, Vector3 endPath, Action<Vector3[], bool> callback)
        {
            this.startPath = startPath;
            this.endPath = endPath;
            this.callback = callback;
        }
    }
    void TryNext()
    {
        if(!processPath && pathRequestQueue.Count > 0)
        {
            currentPathRequest = pathRequestQueue.Dequeue();
            processPath = true;
            pathfinding_script.FindStartPath(currentPathRequest.startPath, currentPathRequest.endPath);
        }
    }

    public void FinishedPath(Vector3[] path,bool finished)
    {
        currentPathRequest.callback(path, finished);
        processPath = false;
        TryNext();
    }
    
}

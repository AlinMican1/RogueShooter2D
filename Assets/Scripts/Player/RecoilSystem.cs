using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystem : MonoBehaviour
{

    Vector3 worldPosition;
    public float distance = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Mousepos = Input.mousePosition;
        Mousepos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(Mousepos);
       
        distance = Vector3.Distance(worldPosition, transform.position);

        
    }
    public float GetDistance()
    {
        return distance;
    }
}

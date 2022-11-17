using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystem : MonoBehaviour
{

    Vector3 worldPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Mousepos = Input.mousePosition;
        Mousepos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(Mousepos);
        print(transform.position);
        float dist = Vector3.Distance(worldPosition, transform.position);
       
        if (dist > 5f)
        {
            print("hallo");
        }
    }
}

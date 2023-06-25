using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystem : MonoBehaviour
{

    Vector3 playerPosition;
    public float distance = 0;


    void Update()
    {
        //Get the mouse position from where the player is located.
        Vector3 Mousepos = Input.mousePosition;
        Mousepos.z = Camera.main.nearClipPlane;
        playerPosition = Camera.main.ScreenToWorldPoint(Mousepos);
        distance = Vector3.Distance(playerPosition, transform.position);


    }
}

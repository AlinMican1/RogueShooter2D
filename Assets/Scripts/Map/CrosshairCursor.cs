using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{

    //Function: Start is called before the first frame update
    void Awake()
    {
        
        Cursor.visible = false; 
    }

    //Function: Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

    }
}

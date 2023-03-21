using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //Variable of type camera to assign it to the main camera and shake it.
    public Camera MainCamera;
    float shakeAmount = 0;

    //Function: Upon starting the game, the Maincamera variable should be assigned to the in game main camera.
    private void Awake()
    {
        //if the variable is not assigned, then assign it.
        if(MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }
    //Function: Shake the camera based on two parameters passed
    public void Shake(float magnitude, float shakeTime )
    {
        shakeAmount = magnitude;
        
        //Control how fast the camera will shake. 
        InvokeRepeating("StartShake", 0, 0.01f);
        Invoke("StopShake", shakeTime);

    }
    
    //Function: This starts the camera shake
    private void StartShake()
    {
        if(shakeAmount > 0)
        {
            //Get the position of the camera and move it based on a random value.
            Vector3 cameraPosition = MainCamera.transform.position;
            
            //A formula for shaking camera on the X axis
            float shakeX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeY = Random.value * shakeAmount * 2 - shakeAmount;
            cameraPosition.x += shakeX;
            cameraPosition.y += shakeY;

            //transform main camera position to the new camera position.
            MainCamera.transform.position = cameraPosition;
        }
    }

    //Function: This stops the camera shake
    private void StopShake()
    {
        //Cancel Camera Shake
        CancelInvoke("StartShake");
        MainCamera.transform.localPosition = Vector3.zero;
    }
    //Function: This updates every frame, However is for testing purposes, So it will not be used during final build.
    private void Update()
    {
        //Tests if the camera shake works, based on key input "T".
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shake(0.1f, 0.2f);
        }
    }

}

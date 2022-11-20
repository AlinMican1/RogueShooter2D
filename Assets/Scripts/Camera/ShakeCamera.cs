using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    /*public IEnumerator Shake(float shakeTime, float shakeDistance)
    {
        float time_elapsed = 0f;
        

        while(time_elapsed < shakeTime)
        {
            float x = (Random.value - 0.5f) * shakeDistance;
            float y = (Random.value - 0.5f) * shakeDistance;
            transform.localPosition = new Vector3(x, y,-5);

            time_elapsed += Time.deltaTime;
            shakeDistance = (1 - (time_elapsed / shakeTime)) * (1 - (time_elapsed / shakeTime));

            yield return null;
        }

        transform.localPosition = Vector2.zero;
        
    }

    private void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = 1;
        
    }
    public void Shake(float shakeTime, float power, float slowDownAmount)
    {
        if(shakeTime > 0)
        {
            camera.localPosition = startPosition + Random.insideUnitSphere * power;
            shakeTime -= Time.deltaTime * slowDownAmount;
        }
        else
        {
            shakeTime = initialDuration;
            camera.localPosition = startPosition;
        }
        startPosition = camera.localPosition;
    }*/

    public Camera MainCamera;
    float shakeAmount = 0;

    private void Awake()
    {
        if(MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }

    public void Shake(float magnitude, float shakeTime )
    {
        shakeAmount = magnitude;
        //Control how fast the camera will shake. 
        InvokeRepeating("StartShake", 0, 0.01f);
        Invoke("StopShake", shakeTime);

    }
    private void StartShake()
    {
        if(shakeAmount > 0)
        {
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

    private void StopShake()
    {
        //Cancel Camera Shake
        CancelInvoke("StartShake");
        MainCamera.transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shake(0.1f, 0.2f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Transform camera;
    Vector3 startPosition;
    float initialDuration;
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
        
    }*/

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Shake(1,1,1);
        }
    }
}

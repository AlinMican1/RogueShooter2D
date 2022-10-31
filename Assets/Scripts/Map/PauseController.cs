using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    
    private bool pause;
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

   
    public void PauseGame()
    {
        
        
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0;
                GamePaused.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                GameResumed.Invoke();
            }
        
    }
}






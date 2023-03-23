using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    //Variables for puasing the game.
    [Header("Variables")]
    private bool pause;
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    
    //Function: This allows to pause the game.
    public void PauseGame()
    {
            //Based on what pause is , set it the opposite.
            pause = !pause;
            //If is on pause then set the time to 0, which pauses the game otherwise set it to 1 which unpauses it.
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






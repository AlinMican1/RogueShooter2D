using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay"); //going to the next scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}

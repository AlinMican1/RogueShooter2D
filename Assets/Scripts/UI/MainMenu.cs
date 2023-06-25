using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay"); //going to the next scene
    }

    public void StoreMenu()
    {
        SceneManager.LoadScene("StoreMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

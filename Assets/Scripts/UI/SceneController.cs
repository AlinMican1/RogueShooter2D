using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   
    public PlayerHealth playerHealth_Script;

    public void Start()
    {
        playerHealth_Script =  GameObject.FindObjectOfType<PlayerHealth>();
    }
    public void GameOver()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

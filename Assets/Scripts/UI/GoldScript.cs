using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
    //Variables for gold game object.
    public Text goldText;
    public int goldNum;
    
    // Start is called before the first frame update
    void Start()
    {
        goldNum = 0;
        goldText.text = "Gold:" + goldNum;
    }

   
    //Function: Check if there is a collision between the player and the gold game object.
    private void OnCollisionEnter2D(Collision2D Gold)
    {
        //Increment the number of gold collected and update text to the number of gold collected.
        if(Gold.gameObject.tag == "Gold")
        {
            goldNum += 1;
            Destroy(Gold.gameObject);
            goldText.text = "Gold:" + goldNum;
            //This is done so we can pass the variable onto another scene which is the death menu scene.
            StateNameController.gold = goldNum;
        }
    }
}

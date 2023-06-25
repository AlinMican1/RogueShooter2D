using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldEarned : MonoBehaviour
{
    
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }


    void Update()
    {
        if(StateNameController.minute >= 5)
        {
            text.text = "Gold Earned: " + StateNameController.gold + " X " + "2" + " = " + StateNameController.gold * 2;
        }
        else if (StateNameController.minute >= 10)
        {
            text.text = "Gold Earned: " + StateNameController.gold + " X " + "3" + " = " + StateNameController.gold * 3;
        }
        else if (StateNameController.minute >= 20)
        {
            text.text = "Gold Earned: " + StateNameController.gold + " X " + "5" + " = " + StateNameController.gold * 5;
        }
        else
        {
            text.text = "Gold Earned: " + StateNameController.gold;
        }


        
    }
}

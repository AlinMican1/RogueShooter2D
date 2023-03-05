using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSurvived : MonoBehaviour
{
    private Text text;
    int minute;
    float minute2;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        
       
    }

    
    void Update()
    {

        print(StateNameController.minute);
        //text.text = "Time: " + Timer_Script.totalMinute + ":" + Timer_Script.totalSecond;
    }
}

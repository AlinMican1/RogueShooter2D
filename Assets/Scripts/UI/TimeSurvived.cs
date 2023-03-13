using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSurvived : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        
       
    }

    
    void Update()
    {

        
        text.text = "Survived: " + StateNameController.minute + ":" + StateNameController.second;
    }
}

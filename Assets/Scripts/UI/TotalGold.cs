using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGold : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }


    void Update()
    {
        text.text = "Total: " + PlayerPrefs.GetInt("gold");


    }
}

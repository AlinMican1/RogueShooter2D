using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GoldScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private int goldNum;
    // Start is called before the first frame update
    void Start()
    {
        goldNum = 0;
        goldText.text = "Gold:" + goldNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D Gold)
    {
        if(Gold.gameObject.tag == "Gold")
        {
            goldNum += 1;
            Destroy(Gold.gameObject);
            goldText.text = "Gold:" + goldNum;
        }
    }
}

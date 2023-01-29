using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplayBuff : MonoBehaviour
{
    public Buff_Card buff_Card;
    // Start is called before the first frame update
    public TextMeshProUGUI nameText;
    public Image Item_Picture;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        nameText.text = buff_Card.name;
        descriptionText.text = buff_Card.description;
        Item_Picture.sprite = buff_Card.artwork;
    }
}

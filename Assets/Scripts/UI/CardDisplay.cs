using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Weapon_Card weapon_Card;
    // Start is called before the first frame update
    public TextMeshProUGUI nameText;
    public Image Item_Picture;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        nameText.text = weapon_Card.name;
        descriptionText.text = weapon_Card.description;
        Item_Picture.sprite = weapon_Card.artwork;
    }
}

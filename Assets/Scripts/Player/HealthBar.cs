using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Variables for setting the health.
    [Header("Variables")]
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    //Function: Set the health slider value.
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(SliderPercent(health));
    }
    //Function: Set the max health and the slider value to that health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public float SliderPercent(int health)
    {
        slider.value = health;
        return slider.value / slider.maxValue;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
   //Reference the slider
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    //Set the health slider value.
    public void SetXP(int experience)
    {
        slider.value = experience;
        fill.color = gradient.Evaluate(SliderPercent(experience));
    }
        //Set the max health and the slider value to that health
    public void SetMinExperience(int Experience)
    {
        slider.minValue = Experience;
        slider.value = Experience;

        fill.color = gradient.Evaluate(0f);
    }

    public float SliderPercent(int experience)
    {   
        slider.value = experience;
        return slider.value / slider.maxValue;
    }
}

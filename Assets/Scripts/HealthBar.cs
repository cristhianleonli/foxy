using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;
    }  

    public void SetHealth(float value)
    {
        slider.value = value;
    }

    public void TopUp()
    {
        slider.value = slider.maxValue;
    }
}

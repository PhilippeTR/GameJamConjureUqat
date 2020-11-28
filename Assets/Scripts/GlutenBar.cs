using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlutenBar : MonoBehaviour
{

    public Slider slider;

    public void SetMinHealth(float health)
    {
        slider.maxValue = 100f;
        slider.minValue = health;
        slider.value = health;

    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

}

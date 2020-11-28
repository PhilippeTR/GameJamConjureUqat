﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlutenBar : MonoBehaviour
{

    public Slider slider;

    public void setMinHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    public void setHealth(float health)
    {
        slider.value = health;
    }

}

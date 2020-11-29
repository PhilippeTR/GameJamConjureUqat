using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField] private int value;

    private void Start()
    {
        value = (int)(Settings.DifficultyMultiplier * value);
    }

    public int getValue()
    {
        return value;
    }

}

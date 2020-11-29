using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Settings
{
    static public float DifficultyMultiplier = 0.25f + (float)PlayerPrefs.GetInt("Difficulty");
}

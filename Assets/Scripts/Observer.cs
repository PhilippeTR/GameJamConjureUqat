﻿using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Damage damage;
    private IntDataBytes _data;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            _data = new IntDataBytes(damage.getValue());
            EventManager.Dispatch("playerGlutenUpdate", _data);
        }
    }
    

}
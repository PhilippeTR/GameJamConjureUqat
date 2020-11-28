using System;
using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;

public class Fall : MonoBehaviour
{

    [SerializeField] private GameObject toastEnemy;
    [SerializeField] private float xSpeed, ySpeed, zSpeed;

    private void Start()
    {
        //toastEnemy.GetComponent<Rigidbody>().useGravity = false;
        toastEnemy.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        toastEnemy.SetActive(false);
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            fallingToast();
        }
    }
    

    private void fallingToast()
    {
        toastEnemy.SetActive(true);
        toastEnemy.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, ySpeed, zSpeed);
        
    }
}

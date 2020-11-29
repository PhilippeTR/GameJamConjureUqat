using System;
using Bytes;
using UnityEngine;


public class ToastFly : MonoBehaviour
{
    public float xSpeed, ySpeed, zSpeed;

    private Vector3 _tempTransform;
    private bool _HasFlown = false;
    

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            if (_HasFlown == false)
            {
                FlyingToast();
                _HasFlown = true;
            }
            
        }
    }

    private void FlyingToast()
    {
        Vector3 speed = new Vector3(xSpeed, ySpeed, zSpeed);
        GetComponent<Rigidbody>().velocity = speed;
        EventManager.Dispatch("playSounds", new PlaySoundData("FlyingToast"));
    }
}

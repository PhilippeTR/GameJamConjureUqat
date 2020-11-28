using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    public JumpingForce jumper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "joueur")
        {
            Debug.Log("joueur");
            jumper.StartGravity();
        }
    }
}

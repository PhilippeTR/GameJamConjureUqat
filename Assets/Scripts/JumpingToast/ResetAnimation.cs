using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimation : MonoBehaviour
{
    public JumpingForce Jumper;
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

        if (other.gameObject.tag == "ResetToast")
        {
            Debug.Log("Collision");
            Jumper.ResetTrigger(false);
        }
    }

}

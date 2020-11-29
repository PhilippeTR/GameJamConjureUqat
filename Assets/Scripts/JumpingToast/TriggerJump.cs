using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    public JumpingForce jumper;
    bool started = false;
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
        if (started) { return; }

        if (other.gameObject.tag == "joueur")
        {
            started = true;
            Debug.Log("joueur");
            Bytes.Animate.Delay(Random.Range(0f, 1.5f), jumper.StartGravity);
        }
    }
}

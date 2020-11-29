using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStopper : MonoBehaviour
{
    public DoorAction door;
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

        if (other.gameObject.tag == "door")
        {
            Debug.Log("Stop incomming");
            door.Stop();
        }
    }
}

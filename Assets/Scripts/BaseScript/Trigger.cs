using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Action act;
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
            Debug.Log("Trigered !!!!");
            act.executeEnter(other.gameObject);
        }
    }
}

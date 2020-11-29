using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFollow : MonoBehaviour
{
    public AudioSource audio;
    public FollowingRotation act;
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
            audio.loop = true;
            audio.Play();
            act.ExecuteEnter();
        }
    }
}

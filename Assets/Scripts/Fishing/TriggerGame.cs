using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGame : MonoBehaviour
{
    public FishingMiniGame act;
    public bool isToaster;
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
            if(isToaster)
                act.NearToaster(true);
            else
                act.ExecuteEnter();
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "joueur")
        {
            if (isToaster)
                act.NearToaster(false);
            else
                act.ExecuteLeave();
        }
    }
}

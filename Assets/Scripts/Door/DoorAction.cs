using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class DoorAction : Action
{
    public bool isNear=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e")) {
            Debug.Log("Activated");
        }
    }
    public void executeEnter(GameObject g)
    {
        isNear = true;
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("E - interact"));
    }
    public void executeStay(GameObject g)
    {

    }
    public void executeLeave(GameObject g)
    {
        isNear = false;
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(""));
    }
}

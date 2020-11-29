using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class DoorAction : MonoBehaviour
{
    public GameObject doorRef;
    public bool isNear=false;
    public bool opening = false;
    public bool opened = false;
    public int time = 10;
    public int speedY = 10;
    public int timer = 10;
    public float angle;
    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {

        v = new Vector3(0, speedY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e")) {
            Debug.Log("Activated");
            opening = true;
        }
        if (opening && !opened) {
            doorRef.transform.Rotate(v, time * Time.deltaTime);
            if (doorRef.transform.rotation.y < angle) {
                Stop();
            }
        }
        if (opened)
        {
            v = new Vector3(0, 0, 0);
            doorRef.transform.Rotate(v, time * Time.deltaTime);
        }
    }

    public void ExecuteEnter()
    {
        isNear = true;
        Debug.Log("Entered");
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("E - Ouvrir la porte"));
    }
    public void ExecuteLeave()
    {
        isNear = false;
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(""));
    }
    public void Stop() {
        Debug.Log("Stop activated");
        opened = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class FishingMiniGame : MonoBehaviour
{
    public GameObject catcher;
    public List<Rotating> rs;
    public int point = 0;
    public GameObject toasterIngame;
    public GameObject toasterInPool;
    public bool inGame;
    public bool nearToaster;
    public bool toaster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            if (Input.GetKey("i"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            if (Input.GetKey("k"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            if (Input.GetKey("j"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
            if (Input.GetKey("l"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
            if (toaster && Input.GetKey("1"))
            {
                toasterInPool.SetActive(true);
                foreach (Rotating r in rs)
                {
                    r.Stop();
                }
            }
        }
        else
        {
            if (nearToaster && Input.GetKey("1"))
            {
                toasterIngame.SetActive(false);
                toaster = true;
            }

        }
    }
    public void ExecuteEnter()
    {
        inGame = true;
        catcher.SetActive(true);
        catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("[i,j,k,l]: control Net [1]: " + ((toaster) ? "Toaster" : "Not Available (find it, then Collect it with [1])")));
    }
    public void ExecuteLeave()
    {
        inGame = false;
        catcher.SetActive(false);
        catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(""));
    }
    public void AddPoint()
    {
        point++;
        if (point > 2)
        {
            inGame = false;
            catcher.SetActive(false);
            catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("You have caught all the toasts!"));
        }

    }
    public void NearToaster(bool _nearToaster)
    {
        nearToaster = _nearToaster;
    }
}

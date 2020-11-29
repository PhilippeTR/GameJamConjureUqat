using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class FishingMiniGame : MonoBehaviour
{
    public GameObject gift;
    public GameObject jumpscare;
    public GameObject catcher;
    public List<Rotating> rs;
    public int point = 0;
    public GameObject toasterIngame;
    public GameObject toasterInPool;
    public bool inGame;
    public bool nearToaster;
    public bool toaster;

    void Update()
    {
        if (inGame)
        {
            if (Input.GetKey("i"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            if (Input.GetKey("k"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            if (Input.GetKey("j"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
            if (Input.GetKey("l"))
                catcher.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
            if (toaster && Input.GetKey("e"))
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
            if (nearToaster && Input.GetKey("e"))
            {
                toasterIngame.SetActive(false);
                toaster = true;
            }

        }
    }
    public void ExecuteEnter()
    {
        if (point > 2)
        {
            inGame = false;
            catcher.SetActive(false);
            catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("Vous avez attrapé toutes les toasts!"));
            
        }
        else {

            inGame = true;
            catcher.SetActive(true);
            catcher.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("I-J-K-L: Jouer: \n" + ((toaster) ? "Ajouter Toaster [E]" : "Trouvez et collectez le avec la touche [E]")));
        }

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
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("Vous avez attrapé toutes les toasts!"));
            if(gift !=null)
                gift.SetActive(true);
            if (jumpscare != null)
                jumpscare.SetActive(true);
        }

    }
    public void NearToaster(bool _nearToaster)
    {
        nearToaster = _nearToaster;
    }
}

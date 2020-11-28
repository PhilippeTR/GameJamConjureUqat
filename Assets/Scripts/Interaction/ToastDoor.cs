﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class ToastDoor : MonoBehaviour
{

    public string keyNeeded = Progession.key1;
    public Animator anim;
    public bool opened;

    public void OpenDoor()
    {
        if (opened) { return; }

        opened = true;
        anim.Play("ToastDoor_open", -1, 0);

        Destroy(this.GetComponent<Collider>());
        Destroy(this);

        EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(""));
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HasKey()) { OpenDoor(); }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            string msg = "E - You need a key!";
            if (HasKey()) { msg = "E - Open door"; }
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(msg));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "joueur")
        {
            EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes(""));
        }
    }

    private bool HasKey()
    {
        return Progession.inventory.Contains(keyNeeded);
    }

}

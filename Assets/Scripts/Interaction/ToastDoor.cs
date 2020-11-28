using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastDoor : MonoBehaviour
{

    public Animator anim;
    public bool opened;

    public void OpenDoor()
    {
        if (opened) { return; }

        opened = true;
        anim.Play("ToastDoor_open", -1, 0);

        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pickable")
        {
            OpenDoor();
        }
    }

}

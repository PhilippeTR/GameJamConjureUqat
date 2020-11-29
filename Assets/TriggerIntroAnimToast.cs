using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIntroAnimToast : MonoBehaviour
{
    public bool hasPlayed = false;
    public Animator anim1;
    public Animator anim2;
    public string anim1Name = "";
    public string anim2Name = "";
    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) { return; }

        if (other.tag == "joueur")
        {
            hasPlayed = true;
            anim1.Play(anim1Name, -1, 0);
            anim2.Play(anim2Name, -1, 0);
        }
    }
}

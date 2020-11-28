using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class CrunchyToastTrap : MonoBehaviour
{
    public int crunchyID;
    public string eventDispatchName = "notifyCrunchyEnemy";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            this.gameObject.SetActive(false);
            EventManager.Dispatch(eventDispatchName + crunchyID, new ObjectDataBytes(other.transform));
            EventManager.Dispatch("playSound", new PlaySoundData("crunchy" + Random.Range(1, 2)));
        }
    }
}

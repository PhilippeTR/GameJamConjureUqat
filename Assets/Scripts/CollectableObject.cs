using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string objectName = "key1";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            if (!Progession.inventory.Contains(objectName))
            {
                Progession.inventory.Add(objectName);
                EventManager.Dispatch("playSound", new PlaySoundData("KeyCapture"));
            }
                
            Destroy(this.gameObject);
        }
    }
}

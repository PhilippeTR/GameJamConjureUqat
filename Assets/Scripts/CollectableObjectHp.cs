using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;

public class CollectableObjectHp : MonoBehaviour
{
    public int glutenRemoved = 25;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            IntDataBytes _data = new IntDataBytes(-glutenRemoved);
            EventManager.Dispatch("playerGlutenUpdate", _data);

            EventManager.Dispatch("playSound", new PlaySoundData("KeyCapture"));
            Destroy(this.gameObject);
        }
    }
}

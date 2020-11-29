using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Damage damage;
    private IntDataBytes _data;
    public float delay = 1.5f;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            
            _data = new IntDataBytes(damage.getValue());
            EventManager.Dispatch("playerGlutenUpdate", _data);
            GetComponent<Collider>().enabled = false;
            
            Animate.Delay(delay, () =>
            {
                GetComponent<Collider>().enabled = true;
            });

        }
    }

}

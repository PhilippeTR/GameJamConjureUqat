using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinJeu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TheEnd");
        }
    }
}

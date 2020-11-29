using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    CanvasGroup cv;
    public UnityEngine.UI.Text txt;
    private void Start()
    {
        cv = GetComponent<CanvasGroup>();
        Bytes.EventManager.AddEventListener("fadeToBlack", (data)=> {
            txt.gameObject.SetActive(true);
            Bytes.Animate.FadeCanvasGroup(cv, 2f, 0f, 1f);
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Bytes;

public class InteractionText : MonoBehaviour
{
    Text text;
    CanvasGroup cv;

    Animate transition;

    private void Start()
    {
        text = GetComponent<Text>();
        cv = GetComponent<CanvasGroup>();

        EventManager.AddEventListener(EventNames.interactionTextUpdate, HandleInteractionTextUpdate);

        //Animate.Delay(3f, ()=> { EventManager.Dispatch(EventNames.interactionTextUpdate, new StringDataBytes("E - interact")); });
    }

    private void HandleInteractionTextUpdate(Bytes.Data data)
    {
        StringDataBytes txt = (StringDataBytes)data;

        if (txt.StringValue == text.text) { return; }

        if (transition != null) { transition.Stop(false); }

        text.text = txt.StringValue;
        if (txt.StringValue == "")
        {
            transition = Animate.FadeCanvasGroup(cv, 0.25f, 1f, 0f, ()=> { transition = null; });
        }
        else
        {
            transition = Animate.FadeCanvasGroup(cv, 0.45f, 0f, 1f, ()=> { transition = null; });
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    Light Light;
    public float maxVariation = 0.2f;
    [Range(0f, 1f)]
    public float varyingFrequency = 0.05f;
    public float transitionSpeed = 0.5f;
    float InitialLightPower;

    float target;
    private void Awake()
    {
        Light = GetComponent<Light>();
        InitialLightPower = Light.intensity;
        //targetLightOuterRadius = InitialLightPower;
    }
    void Update()
    {
        float rd = Random.Range(0f, 1f);
        if (rd > 1f - varyingFrequency)
        {
            target = Random.Range(InitialLightPower - maxVariation, InitialLightPower + maxVariation);
        }
        Light.intensity = Mathf.Lerp(Light.intensity, target, Time.deltaTime * transitionSpeed);
    }
}

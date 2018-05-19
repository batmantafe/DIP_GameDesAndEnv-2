using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Light flameLight;

    public float flameStartRange, flameStartIntensity;

    public float fuelMax, fuelCurrent, burnRate;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        BurnDown();
    }

    void StartConditions()
    {
        flameLight = GetComponent<Light>();

        fuelMax = 100f;
        fuelCurrent = fuelMax;
        burnRate = 30f;

        flameStartRange = flameLight.range;
        flameStartIntensity = flameLight.intensity;
    }

    void BurnDown()
    {
        fuelCurrent = fuelCurrent - (fuelMax / burnRate * Time.deltaTime);

        //Debug.Log(fuelCurrent);

        if (fuelCurrent > 0f)
        {
            flameLight.range = flameLight.range - (flameStartRange / burnRate * Time.deltaTime);
            flameLight.intensity = flameLight.intensity - (flameStartIntensity / burnRate * Time.deltaTime);
        }

        if (fuelCurrent <= 0f)
        {
            fuelCurrent = 0f;
        }
    }
}

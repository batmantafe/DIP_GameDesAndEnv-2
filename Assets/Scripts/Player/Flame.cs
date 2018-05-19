using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Light flameLight;

    public float flameStartRange, flameStartIntensity;

    public float fuelMax, fuelCurrent, burnRate;

    public Color flameColourMax, flameColour;
    public Renderer rend;

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
        burnRate = 150f;

        flameStartRange = flameLight.range;
        flameStartIntensity = flameLight.intensity;

        rend = GetComponent<Renderer>();
        flameColourMax = rend.material.color;
        flameColour = flameColourMax;

        Debug.Log(flameColour);
    }

    void BurnDown()
    {
        fuelCurrent = fuelCurrent - (fuelMax / burnRate * Time.deltaTime);

        //Debug.Log(fuelCurrent);

        if (fuelCurrent > 0f)
        {
            flameLight.range = flameLight.range - (flameStartRange / burnRate * Time.deltaTime);
            flameLight.intensity = flameLight.intensity - (flameStartIntensity / burnRate * Time.deltaTime);

            // Faking Colour Lerp
            flameColour.r = flameColour.r - (flameColourMax.r / burnRate * Time.deltaTime);
            flameColour.g = flameColour.g - (flameColourMax.g / (burnRate / 2f) * Time.deltaTime);
            rend.material.color = flameColour;
        }

        if (fuelCurrent <= 0f)
        {
            fuelCurrent = 0f;
        }
    }
}

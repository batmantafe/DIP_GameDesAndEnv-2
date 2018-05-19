using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{
    public Light torchLight;

    public float torchStartRange, torchStartIntensity;

    public float fuelMax, fuelCurrent, burnRate;

    public Color torchColourMax, torchColour;
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
        torchLight = GetComponent<Light>();

        fuelMax = 100f;
        fuelCurrent = fuelMax;
        burnRate = 300f; // in seconds

        torchStartRange = torchLight.range;
        torchStartIntensity = torchLight.intensity;

        rend = GetComponent<Renderer>();
        torchColourMax = rend.material.color;
        torchColour = torchColourMax;

        //Debug.Log(torchColour);
    }

    void BurnDown()
    {
        fuelCurrent = fuelCurrent - (fuelMax / burnRate * Time.deltaTime);

        //Debug.Log(fuelCurrent);

        if (fuelCurrent > 0f)
        {
            torchLight.range = torchLight.range - (torchStartRange / burnRate * Time.deltaTime);
            torchLight.intensity = torchLight.intensity - (torchStartIntensity / burnRate * Time.deltaTime);

            // Faking Colour Lerp
            torchColour.r = torchColour.r - (torchColourMax.r / burnRate * Time.deltaTime);
            torchColour.g = torchColour.g - (torchColourMax.g / (burnRate / 2f) * Time.deltaTime);
            rend.material.color = torchColour;
        }

        if (fuelCurrent <= 0f)
        {
            fuelCurrent = 0f;
        }
    }
}

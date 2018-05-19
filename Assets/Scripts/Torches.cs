using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{
    public Light torchLight;

    public float torchStartRange, torchStartIntensity;

    public float fuelMax, fuelCurrent, burnRate, greenFuel;

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
        burnRate = 600f;

        torchStartRange = torchLight.range;
        torchStartIntensity = torchLight.intensity;

        rend = GetComponent<Renderer>();
        torchColourMax = rend.material.color;
        torchColour = torchColourMax;

        greenFuel = torchColourMax.g * 100;
    }

    void BurnDown()
    {
        fuelCurrent = fuelCurrent - (fuelMax / burnRate * Time.deltaTime);
        greenFuel = greenFuel - (fuelMax / (burnRate / 2f) * Time.deltaTime);

        torchLight.range = (fuelCurrent / fuelMax) * torchStartRange;
        torchLight.intensity = (fuelCurrent / fuelMax) * torchStartIntensity;

        torchColour.r = (fuelCurrent / fuelMax) * torchColourMax.r;
        torchColour.g = (greenFuel / fuelMax) * torchColourMax.g;
        rend.material.color = torchColour;

        //Debug.Log("Flame: " + rend.material.color + " & FuelCurrent: " + fuelCurrent);

        // Debugging Fuel
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            fuelCurrent = fuelMax;
            greenFuel = torchColourMax.g * 100f;
        }*/

        if (fuelCurrent > fuelMax)
        {
            fuelCurrent = fuelMax;
        }

        if (fuelCurrent <= 0f)
        {
            fuelCurrent = 0f;
        }

        if (greenFuel <= 0f)
        {
            greenFuel = 0f;
        }
    }
}

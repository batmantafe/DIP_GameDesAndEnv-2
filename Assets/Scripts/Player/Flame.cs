using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Light flameLight;

    public float flameStartRange, flameStartIntensity;

    public float fuelMax, fuelCurrent, burnRate, greenFuel;

    public Color flameColourMax, flameColour;
    public Renderer rend;

    public GameObject playerObject;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        BurnDown();

        // For Debugging/Playtesting only
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            fuelCurrent = fuelMax;
            greenFuel = flameColourMax.g * 100f;
        }*/
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

        greenFuel = flameColourMax.g * 100;
    }

    void BurnDown()
    {
        fuelCurrent = fuelCurrent - (fuelMax / burnRate * Time.deltaTime);
        greenFuel = greenFuel - (fuelMax / (burnRate / 2f) * Time.deltaTime);

        flameLight.range = (fuelCurrent / fuelMax) * flameStartRange;
        flameLight.intensity = (fuelCurrent / fuelMax) * flameStartIntensity;

        flameColour.r = (fuelCurrent / fuelMax) * flameColourMax.r;
        flameColour.g = (greenFuel / fuelMax) * flameColourMax.g;
        rend.material.color = flameColour;

        //Debug.Log("Flame: " + rend.material.color + " & FuelCurrent: " + fuelCurrent);

        // Refuel
        if (playerObject.GetComponent<PlayerInput>().playerAtBonfire == true && Input.GetKeyDown(KeyCode.Space))
        {
            fuelCurrent = fuelMax;
            greenFuel = flameColourMax.g * 100f;
        }

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

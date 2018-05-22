using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Torches : MonoBehaviour
{
    public Light torchLight;

    public float torchStartRange, torchStartIntensity;

    public float fuelMax, fuelCurrent, burnRate, greenFuel;

    public Color torchColourMax, torchColour;
    public Renderer rend;

    public GameObject manager;

    // Use this for initialization
    void Start()
    {
        StartConditions();

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            manager = GameObject.Find("Menu Manager");
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            manager = GameObject.Find("GameManager");

            torchStartRange = manager.GetComponent<GameManager>().savedLightRange;
            torchStartIntensity = manager.GetComponent<GameManager>().savedLightIntensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BurnDown();

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            manager = GameObject.Find("Menu Manager");

            torchStartRange = manager.GetComponent<MenuManager>().sliderRange;
            torchStartIntensity = manager.GetComponent<MenuManager>().sliderIntensity;
        }
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

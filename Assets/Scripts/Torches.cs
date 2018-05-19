using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{

    public Light torchLight;

    public float torchStartRange, torchStartIntensity;

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
        torchLight = GetComponent<Light>();

        fuelMax = 100f;
        fuelCurrent = fuelMax;
        burnRate = 10f;

        torchStartRange = torchLight.range;
        torchStartIntensity = torchLight.intensity;
    }

    void BurnDown()
    {
        torchLight.range = torchLight.range - (torchStartRange / burnRate * Time.deltaTime);
        torchLight.intensity = torchLight.intensity - (torchStartIntensity / burnRate * Time.deltaTime);
    }
}

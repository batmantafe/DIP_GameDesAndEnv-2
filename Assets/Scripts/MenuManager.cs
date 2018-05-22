using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider lightSlider;

    public GameObject[] torchesArray;

    public int easyRange, normalRange, hardRange, sliderRange, easyIntensity, normalIntensity, hardIntensity, sliderIntensity;

    public int lightSliderValue;

    // Use this for initialization
    void Start()
    {
        easyRange = 12;
        normalRange = 8;
        hardRange = 4;

        easyIntensity = 4;
        normalIntensity = 2;
        hardIntensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        LightSliderFunction();
    }

    public void LightSliderFunction()
    {
        if (lightSlider.value == 1)
        {
            //Debug.Log("Let there be light!");

            lightSliderValue = 1;

            sliderRange = easyRange;
            sliderIntensity = easyIntensity;
        }

        if (lightSlider.value == 2)
        {
            //Debug.Log("How it should be played.");

            lightSliderValue = 2;

            sliderRange = normalRange;
            sliderIntensity = normalIntensity;
        }

        if (lightSlider.value == 3)
        {
            //Debug.Log("Challenging!");

            lightSliderValue = 3;

            sliderRange = hardRange;
            sliderIntensity = hardIntensity;
        }

        TorchControl();
    }

    void TorchControl()
    {
        for (int i = 0; i < torchesArray.Length; i++)
        {
            torchesArray[i].GetComponent<Light>().range = sliderRange;
            torchesArray[i].GetComponent<Light>().intensity = sliderIntensity;
        }
    }
}

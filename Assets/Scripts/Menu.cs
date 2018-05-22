using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text aboveText, belowText;

    public int getPlayerStatus;

    public int lightLevel;

    public GameObject menuManager;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;

        getPlayerStatus = PlayerPrefs.GetInt("Player Win/Lose");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");

        PlayerPrefs.SetInt("LightRange", menuManager.GetComponent<MenuManager>().sliderRange);
        PlayerPrefs.SetInt("LightIntensity", menuManager.GetComponent<MenuManager>().sliderIntensity);
        PlayerPrefs.SetInt("Difficulty", menuManager.GetComponent<MenuManager>().lightSliderValue);
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("Player Win/Lose", 0);

        Application.Quit();
    }

    void CheckPlayerStatus()
    {
        //getPlayerStatus = PlayerPrefs.GetInt("Player Win/Lose");

        switch (getPlayerStatus)
        { 
        case 0:
                aboveText.text = "Immortality lies at the feet of the Silent Colossus in";
                belowText.text = "Get there before the Lights burn out.";
                break;

        case 1:
                aboveText.text = "You have become the new Silent Colossus of";
                belowText.text = "You will scream forever... silently.";
                break;

        case 2:
                aboveText.text = "Yes,";
                belowText.text = "is very scary.";
                break;

        case 3:
                aboveText.text = "In your haste you forgot gravity.";
                belowText.text = "laughs at your stupidity.";
                break;

        case 4:
                aboveText.text = "";
                belowText.text = "feeds on your Soul.";
                break;

        case 5:
                aboveText.text = "";
                belowText.text = "has swallowed you whole.";
                break;
        }
    }
}

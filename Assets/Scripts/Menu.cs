using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text aboveText, belowText;

    public int getPlayerStatus;

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
                aboveText.text = "";
                belowText.text = "";
                break;

        case 1:
                aboveText.text = "You are the new Lich of";
                belowText.text = "";
                break;

        case 2:
                aboveText.text = "You ran screaming from";
                belowText.text = "";
                break;

        case 3:
                aboveText.text = "You'd rather jump than face";
                belowText.text = "";
                break;

        case 4:
                aboveText.text = "";
                belowText.text = "took your Soul";
                break;

        case 5:
                aboveText.text = "Darkness swallowed you whole in";
                belowText.text = "";
                break;
        }
    }
}

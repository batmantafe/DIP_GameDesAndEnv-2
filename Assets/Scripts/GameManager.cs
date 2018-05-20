using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerWon, playerLost;

    public int playerStatus;

    public Torches torchSample;

    public PlayerInput playerInput;
    public GameObject bonfireTrigger, bonfireFire;

    public GameObject statue1, statue2;

    // Use this for initialization
    void Start()
    {
        playerWon = false;
        playerLost = false;

        playerStatus = 0;

        PlayerPrefs.SetInt("Player Win/Lose", playerStatus);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();

        //Debug.Log(playerStatus);

        if (torchSample.fuelCurrent <= 0f)
        {
            playerStatus = 5;

            playerLost = true;
        }
    }

    void CheckPlayer()
    {
        if (playerWon == true)
        {
            Debug.Log("Player Won!");

            PlayerPrefs.SetInt("Player Win/Lose", playerStatus);

            SceneManager.LoadScene("Menu");
        }

        if (playerLost == true)
        {
            Debug.Log("Player Lost!");

            PlayerPrefs.SetInt("Player Win/Lose", playerStatus);

            SceneManager.LoadScene("Menu");
        }

        if (playerInput.playerHasLastKey == true)
        {
            bonfireTrigger.SetActive(false);

            bonfireFire.SetActive(false);

            statue1.SetActive(false);
            statue2.SetActive(true);
        }
    }
}

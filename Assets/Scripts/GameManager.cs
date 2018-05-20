using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerWon, playerLost;

    public int playerStatus;

    // Use this for initialization
    void Start()
    {
        playerWon = false;
        playerLost = false;

        playerStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
    }

    void CheckPlayer()
    {
        if (playerWon == true)
        {
            Debug.Log("Player Won!");

            SceneManager.LoadScene("Menu");
        }

        if (playerLost == true)
        {
            Debug.Log("Player Lost!");

            SceneManager.LoadScene("Menu");
        }
    }
}

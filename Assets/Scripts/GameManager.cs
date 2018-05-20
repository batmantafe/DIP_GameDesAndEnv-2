using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerWon, playerLost;

    // Use this for initialization
    void Start()
    {
        playerWon = false;
        playerLost = false;
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

            SceneManager.LoadScene("Game");
        }

        if (playerLost == true)
        {
            Debug.Log("Player Lost!");

            SceneManager.LoadScene("Game");
        }
    }
}

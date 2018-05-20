using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public bool playerHasFirstKey, playerHasLastKey;

    public Text playerMessage;

    public bool playerAtBonfire;

    public GameManager gameManager;

    public bool playerOnLastElevator;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        Shortcuts();
    }

    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();

            gameManager.playerStatus = 2;

            //Debug.Log(gameManager.playerStatus);

            gameManager.playerLost = true;
        }

        // For Debugging/Playtesting Only
        /********************************/
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Time.timeScale = 4f;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 1f;
        }
        /*******************************/
    }

    void StartConditions()
    {
        Cursor.visible = false;

        playerHasFirstKey = false;
        playerHasLastKey = false;

        playerAtBonfire = false;

        playerOnLastElevator = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("First Key"))
        {
            other.gameObject.SetActive(false);

            playerHasFirstKey = true;
        }

        if (other.gameObject.CompareTag("First Button"))
        {
            playerMessage.text = "You can Press SPACE to use Buttons and Levers.";
        }

        if (other.gameObject.CompareTag("Bonfire"))
        {
            playerAtBonfire = true;

            playerMessage.text = "You can Press SPACE to refuel your Torch.";
        }

        if (other.gameObject.CompareTag("Last Key"))
        {
            other.gameObject.SetActive(false);

            playerHasLastKey = true;
        }

        if (other.gameObject.name == "Falling Floor")
        {
            gameManager.playerStatus = 3;

            gameManager.playerLost = true;
        }

        if (other.gameObject.CompareTag("The End"))
        {
            gameManager.playerStatus = 1;

            gameManager.playerWon = true;
        }

        if (other.gameObject.CompareTag("Last Trigger"))
        {
            playerOnLastElevator = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("First Button"))
        {
            playerMessage.text = "";
        }

        if (other.gameObject.CompareTag("Bonfire"))
        {
            playerAtBonfire = false;

            playerMessage.text = "";
        }
    }
}

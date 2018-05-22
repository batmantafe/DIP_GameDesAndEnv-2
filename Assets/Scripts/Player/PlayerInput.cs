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

    public bool playerCanTakeFirstKey, playerCanTakeLastKey;

    public GameObject firstKey, lastKey;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        Shortcuts();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerCanTakeFirstKey == true)
            {
                firstKey.gameObject.SetActive(false);

                playerHasFirstKey = true;

                playerMessage.text = "";
            }

            if (playerCanTakeLastKey == true)
            {
                lastKey.gameObject.SetActive(false);

                playerHasLastKey = true;
            }
        }
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
            Time.timeScale = 6f;
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
        if (other.gameObject.CompareTag("First Key") && playerCanTakeFirstKey == false)
        {
            playerMessage.text = "A Key without a Keyhole. Press SPACE to take this Key.";

            playerCanTakeFirstKey = true;
        }

        if (other.gameObject.CompareTag("First Button") && playerHasFirstKey == true)
        {
            playerMessage.text = "You can Press SPACE to use Keyholes (if you have the right Keys) and Levers.";
        }

        if (other.gameObject.CompareTag("First Button") && playerHasFirstKey == false)
        {
            playerMessage.text = "A Keyhole without a Key...";
        }

        if (other.gameObject.CompareTag("Bonfire"))
        {
            playerAtBonfire = true;

            playerMessage.text = "You can Press SPACE to refuel your Torch.";
        }

        if (other.gameObject.CompareTag("Last Key"))
        {
            playerCanTakeLastKey = true;
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

        if (other.gameObject.CompareTag("First Key"))
        {
            playerMessage.text = "";

            playerCanTakeFirstKey = false;
        }
    }
}

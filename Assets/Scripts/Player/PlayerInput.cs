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
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void StartConditions()
    {
        Cursor.visible = false;

        playerHasFirstKey = false;
        playerHasLastKey = false;

        playerAtBonfire = false;
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

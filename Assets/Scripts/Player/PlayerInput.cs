using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public bool playerHasFirstKey;

    public Text playerMessage;

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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("First Button"))
        {
            playerMessage.text = "";
        }
    }
}

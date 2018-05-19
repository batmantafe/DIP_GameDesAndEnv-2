using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public bool playerHasFirstKey;

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
        playerHasFirstKey = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("First Key"))
        {
            other.gameObject.SetActive(false);

            playerHasFirstKey = true;
        }
    }
}

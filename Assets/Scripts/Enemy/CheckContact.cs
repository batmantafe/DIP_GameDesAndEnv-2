using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContact : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerInput playerInput;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && playerInput.playerHasLastKey == true)
        {
            Debug.Log("Enemy touched Player");

            gameManager.playerStatus = 4;

            gameManager.playerLost = true;
        }
    }
}

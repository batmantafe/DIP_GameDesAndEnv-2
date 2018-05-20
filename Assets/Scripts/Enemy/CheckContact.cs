using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContact : MonoBehaviour
{
    public GameManager gameManager;

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
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Enemy touched Player");

            gameManager.playerLost = true;
        }
    }
}

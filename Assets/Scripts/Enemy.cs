using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent nav;

    public bool getPlayerBool;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();

        getPlayerBool = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getPlayer();

        if (getPlayerBool == true)
        {
            nav.SetDestination(player.transform.position);
        }
    }

    void getPlayer()
    {
        if (player.GetComponent<PlayerInput>().playerHasLastKey == true)
        {
            getPlayerBool = true;
        }
    }
}

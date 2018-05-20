using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    public GameObject player, flame;

    private NavMeshAgent nav;

    public bool activateEnemy, chasePlayer;

    public SphereCollider enemySphere;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        enemySphere = GetComponent<SphereCollider>();

        activateEnemy = false;
        chasePlayer = false;
    }

    // Use this for initialization
    void Start()
    {
        enemySphere.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayer();

        if (activateEnemy == true)
        {
            nav.SetDestination(player.transform.position);
        }
    }

    void GetPlayer()
    {
        if (player.GetComponent<PlayerInput>().playerHasLastKey == true)
        {
            activateEnemy = true;

            enemySphere.enabled = true;
        }

        if (enemySphere.enabled)
        {
            enemySphere.radius = Mathf.Ceil(flame.GetComponent<Flame>().flameLight.range);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && enemySphere.radius != 0f)
        {
            nav.Stop();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" && enemySphere.radius != 0f)
        {
            nav.Resume();
        }
    }
}

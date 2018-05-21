using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject door;
    public Transform doorTarget;

    public float doorSpeed;

    public bool doorOn;
    public bool doorDone;
    public bool playerAtLever;

    public GameObject stoneSound;

    void Start()
    {
        doorOn = false;
        doorDone = false;
        playerAtLever = false;

        doorSpeed = .5f;
    }

    void Update()
    {
        if (doorOn == true)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorTarget.position, doorSpeed * Time.deltaTime);

            transform.Rotate(new Vector3 (0, -30, 0) * (doorSpeed * Time.deltaTime));

            stoneSound.SetActive(true);
        }

        if (door.transform.position == doorTarget.position)
        {
            doorDone = true;
            doorOn = false;
        }

        if (playerAtLever == true && Input.GetKeyDown(KeyCode.Space))
        {
            doorOn = true;
        }

        if (doorOn == false)
        {
            stoneSound.SetActive(false);
        }

        //Debug.Log(door.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // IF Player at Lever, AND Door not already moving, THEN Door ready to work
        if (other.gameObject.name == "Player" &&
            doorOn == false &&
            doorDone == false)
        {
            playerAtLever = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // IF Player leaves Lever
        if (other.gameObject.name == "Player")
        {
            playerAtLever = false;
        }
    }
}

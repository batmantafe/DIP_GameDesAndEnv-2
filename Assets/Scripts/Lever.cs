using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject door;
    public Transform doorTarget;

    public float doorSpeed;

    public bool doorOn;
    public bool doorDone;
    public bool playerAtDoor;

    void Start()
    {
        doorOn = false;
        doorDone = false;
        playerAtDoor = false;

        doorSpeed = .5f;
    }

    void Update()
    {
        if (doorOn == true)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorTarget.position, doorSpeed * Time.deltaTime);

            transform.

            transform.Rotate(new Vector3 (0, -30, 0) * (doorSpeed * Time.deltaTime));
        }

        if (door.transform.position == doorTarget.position)
        {
            doorDone = true;
            doorOn = false;
        }

        if (playerAtDoor == true && Input.GetKeyDown(KeyCode.Space))
        {
            doorOn = true;
        }

        Debug.Log(door.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // IF Player at Elevator, AND Elevator not already moving, AND Key deactivated, THEN Elevator ready to work
        if (other.gameObject.name == "Player" &&
            doorOn == false &&
            doorDone == false)
        {
            playerAtDoor = true;
        }
    }
}

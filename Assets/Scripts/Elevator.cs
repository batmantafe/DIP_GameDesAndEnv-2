using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject key;

    public GameObject platform;
    public Transform platformTarget;

    public float elevatorSpeed;

    public bool elevatorOn;
    public bool elevatorDone;
    public bool elevatorReady;

    public GameObject stoneSound;

    void Start()
    {
        elevatorOn = false;
        elevatorDone = false;
        elevatorReady = false;

        elevatorSpeed = .5f;
    }

    void Update()
    {
        if (elevatorOn == true)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, platformTarget.position, elevatorSpeed * Time.deltaTime);

            stoneSound.SetActive(true);
        }

        if (platform.transform.position == platformTarget.position)
        {
            elevatorDone = true;
            elevatorOn = false;
        }

        if (elevatorReady == true && Input.GetKeyDown(KeyCode.Space))
        {
            elevatorOn = true;
        }

        if (elevatorOn == false)
        {
            stoneSound.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // IF Player at Elevator, AND Elevator not already moving, AND Key deactivated, THEN Elevator ready to work
        if (other.gameObject.name == "Player" &&
            elevatorOn == false &&
            elevatorDone == false &&
            key.activeSelf == false)
        {
            elevatorReady = true;
        }
    }
}

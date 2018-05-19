using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject key;

    public GameObject platform;
    public Transform platformTarget;

    public float elevatorSpeed;

    private bool elevatorOn;
    private bool elevatorDone;

    void Start()
    {
        elevatorOn = false;
        elevatorDone = false;

        elevatorSpeed = .5f;
    }

    void Update()
    {
        if (elevatorOn == true)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, platformTarget.position, elevatorSpeed * Time.deltaTime);
        }

        if (platform.transform.position == platformTarget.position)
        {
            elevatorDone = true;
            elevatorOn = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" &&
            elevatorOn == false &&
            elevatorDone == false &&
            key.activeSelf == false)
        {
            //other.gameObject.transform.parent = platform.transform;

            elevatorOn = true;
        }
    }
}

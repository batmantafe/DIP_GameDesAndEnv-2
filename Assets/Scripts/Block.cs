using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Transform blockTarget;

    public float blockSpeed;

    // Use this for initialization
    void Start()
    {
        blockSpeed = .0067f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, blockTarget.position, blockSpeed * Time.deltaTime);
    }
}

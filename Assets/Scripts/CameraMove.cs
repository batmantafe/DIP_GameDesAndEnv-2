using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform camTarget;

    public float camSpeed;

    public GameObject blockLight;

    // Use this for initialization
    void Start()
    {
        camSpeed = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, camTarget.position, camSpeed * Time.deltaTime);

        if (transform.position == camTarget.position)
        {
            blockLight.SetActive(true);
        }
    }
}

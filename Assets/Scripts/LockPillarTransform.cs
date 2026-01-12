using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPillarTransform : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 coordinates;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        coordinates = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = coordinates;
        transform.rotation = rotation;
    }
}

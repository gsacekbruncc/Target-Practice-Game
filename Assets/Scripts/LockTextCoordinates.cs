using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTextCoordinates : MonoBehaviour
{
    //public GameObject[] targets;
    
    Vector3 coordinates;

    // Start is called before the first frame update
    void Start()
    {
        coordinates = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = coordinates;
    }
}

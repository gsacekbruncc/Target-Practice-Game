using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPosition : MonoBehaviour
{
    public Camera c; 
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        float cameraX = p.transform.position.x;
        float cameraZ = p.transform.position.z;
        float cameraY = p.transform.position.y;

        c.transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

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
        ResetCamera();
    }

    public void ResetCamera()
    {
        float cameraX = p.transform.position.x;
        float cameraZ = p.transform.position.z;
        float cameraY = p.transform.position.y + .01f;

        c.transform.position = new Vector3(cameraX, cameraY, cameraZ);

        p.transform.position = new Vector3(0f, 0.9f, -6.204f);
        p.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        c.GetComponent<LookCharacter>().SetPitch(0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

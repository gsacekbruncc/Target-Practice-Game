using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementSensitivity : MonoBehaviour
{
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if(Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.gameObject.CompareTag("IncrementSensitivity"))
                {
                    Debug.Log("Right hit");
                    GetComponent<Slider>().value += .01f;
                }
                if(hit.collider.gameObject.CompareTag("DecrementSensitivity"))
                {
                    Debug.Log("Left hit");
                    GetComponent<Slider>().value -= .01f;
                }
            }
        }    
    }
}

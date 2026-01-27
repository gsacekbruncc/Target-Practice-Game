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
            float sensitivity = GetComponent<Slider>().value;

            if (Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.gameObject.CompareTag("IncrementSensitivity"))
                {
                    GetComponent<Slider>().value += .01f;
                    SaveManager.SaveSensitivity(sensitivity + .01f);
                }
                if(hit.collider.gameObject.CompareTag("DecrementSensitivity"))
                {
                    GetComponent<Slider>().value -= .01f;
                    SaveManager.SaveSensitivity(sensitivity - .01f);
                }
            }
        }    
    }
}

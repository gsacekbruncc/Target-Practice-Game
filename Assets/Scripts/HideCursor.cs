using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Make cursor invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

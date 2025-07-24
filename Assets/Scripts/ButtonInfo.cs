using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{

    Camera cam;
    GameObject button;

    public GameObject subMenu;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        button = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

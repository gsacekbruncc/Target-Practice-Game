using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
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
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject == button)
            {
                subMenu.SetActive(true);
                var gameHandler = GameObject.Find("Game Handler");
            }
        }
    }
}

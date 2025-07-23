using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    Camera cam;
    GameObject button;
    
    public GameObject[] buttons;

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

            if(Physics.Raycast(ray, out var hit) && buttons.Contains(hit.collider.gameObject))
            {   
                var currButton = hit.collider.gameObject;
                GameObject currSubMenu = currButton.GetComponent<ClickButton>().subMenu;
                int currId = currButton.GetComponent<ClickButton>().id;
                
                if(currId == 1)
                {
                    currSubMenu.SetActive(true);
                }
                else if(buttons[0].GetComponent<ClickButton>().subMenu.activeInHierarchy)
                {
                    buttons[0].GetComponent<ClickButton>().subMenu.SetActive(false);
                }

                if(currId == 2)
                {
                    currSubMenu.SetActive(true);
                }
                else if(buttons[1].GetComponent<ClickButton>().subMenu.activeInHierarchy)
                {
                    buttons[1].GetComponent<ClickButton>().subMenu.SetActive(false);
                }
            }
        }
    }
}

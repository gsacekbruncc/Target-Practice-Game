using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    Camera cam;
    GameObject button;
    
    public GameObject[] buttons;
    public GameObject quitButton;

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
            var hitInfo = Physics.Raycast(ray, out var hit);
            if(hitInfo && buttons.Contains(hit.collider.gameObject))
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

                if(currId == 3)
                {
                    Application.Quit();
                }
            }
            else if(hitInfo && hit.collider.gameObject == quitButton)
            {   
                #if UNITY_STANDALONE
                    Application.Quit();
                #endif
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApplyCrosshair : MonoBehaviour
{
    public Image[] crosshairRep;
    public Image[] crosshairScreen;
    public Slider spread;
    
    Camera cam;
    //float scale = 0.004800001f;

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

            if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject.CompareTag("ApplyCrosshair"))
            {
                if(crosshairRep != null && crosshairScreen != null)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        
                        var st = crosshairScreen[i].rectTransform;
                        var rt = crosshairRep[i].rectTransform;

                        Vector2 rawSize = rt.sizeDelta;
                        Vector2 rawPos  = rt.anchoredPosition;

                        Vector2 pixelSize = new Vector2(Mathf.Round(rawSize.x), Mathf.Round(rawSize.y));
                        Vector2 pixelPos = new Vector2(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y));
                        
                        st.sizeDelta = pixelSize;
                        st.anchoredPosition = pixelPos;
                    }
                }
            }
        }
    }
}
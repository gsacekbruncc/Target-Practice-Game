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
    bool saved;
    //float scale = 0.004800001f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if(SaveManager.GetSaved())
        {
            RestoreCrosshair();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject.CompareTag("ApplyCrosshair"))
            {
                SetCrosshair();
            }
        }
    }

    public void SetCrosshair()
    {
        if(crosshairRep != null && crosshairScreen != null)
        {
            Vector2 savedSize = Vector2.zero;
            Vector2 savedPos = Vector2.zero;

            for (int i = 0; i < 4; i++)
            {

                var st = crosshairScreen[i].rectTransform;
                var rt = crosshairRep[i].rectTransform;

                Vector2 rawSize = rt.sizeDelta;
                Vector2 rawPos = rt.anchoredPosition;

                Vector2 pixelSize = new Vector2(Mathf.Round(rawSize.x), Mathf.Round(rawSize.y));
                Vector2 pixelPos = new Vector2(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y));

                st.sizeDelta = pixelSize;
                st.anchoredPosition = pixelPos;

                savedSize = pixelSize;
                savedPos = pixelPos;

                SaveManager.SaveScreenSpaceCrosshairTick("CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY", i, pixelSize);
                SaveManager.SaveScreenSpaceCrosshairTick("CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY", i, pixelPos);
            }
            SaveManager.SetSaved();
        }
    }
    public void RestoreCrosshair()
    {
        if(crosshairRep != null && crosshairScreen != null)
        {
            for(int i = 0; i < 4; i++)
            {
                Vector2 pixelSize = SaveManager.GetScreenSpaceCrosshairSizeDelta(i);
                Vector2 pixelPos = SaveManager.GetScreenSpaceCrosshairAnchoredPosition(i);

                var st = crosshairScreen[i].rectTransform;
                st.sizeDelta = pixelSize;
                st.anchoredPosition = pixelPos;
            }

        }
    }
}
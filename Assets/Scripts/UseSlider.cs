using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UseSlider : MonoBehaviour
{
    Camera cam;
    Slider slider;
    float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        cam = Camera.main;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if(Physics.Raycast(ray, out var hit))
            {
                var hitSlider = hit.collider.GetComponent<Slider>();
                if(hitSlider == slider)
                {
                    RectTransform rt = slider.GetComponent<RectTransform>();
                    Vector2 lp = rt.InverseTransformPoint(hit.point);

                    float t = Mathf.InverseLerp(rt.rect.xMin, rt.rect.xMax, lp.x);
                    slider.value = Mathf.Lerp(slider.maxValue, slider.minValue, t);
                    
                    sliderValue = slider.value;
                    
                }
            }
        }    
    }
    
    public void OnSliderValueChanged(float sliderValue)
    {
        if(gameObject.name == "Sensitivity")
        {
            SaveManager.SaveSensitivity(sliderValue);
        }
        if(gameObject.name == "Crosshair Length")
        {
            SaveManager.SaveCrosshairLengthSliderValue(sliderValue);
        }
        if(gameObject.name == "Crosshair Width")
        {
            SaveManager.SaveCrosshairWidthSliderValue(sliderValue);
        }
        if(gameObject.name == "Crosshair Spread")
        {
            SaveManager.SaveCrosshairSpreadSliderValue(sliderValue);
        }
    }
}

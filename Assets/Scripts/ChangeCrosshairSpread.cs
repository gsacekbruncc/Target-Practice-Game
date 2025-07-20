using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCrosshairSpread : MonoBehaviour
{
    Slider slider;

    public Image leftTick;
    public Image rightTick;
    public Image topTick;
    public Image bottomTick;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {   
        var lt = leftTick.rectTransform;
        var rt = rightTick.rectTransform;
        var tt = topTick.rectTransform;
        var bt = bottomTick.rectTransform;

        var sVal = slider.value;

        lt.anchoredPosition = new Vector2(-slider.value, lt.anchoredPosition.y);
        rt.anchoredPosition = new Vector2(slider.value, rt.anchoredPosition.y);
        tt.anchoredPosition = new Vector2(tt.anchoredPosition.x, slider.value);
        bt.anchoredPosition = new Vector2(bt.anchoredPosition.x, -slider.value);


    }
}

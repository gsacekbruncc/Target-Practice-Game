using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCrosshairLength : MonoBehaviour
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

        lt.sizeDelta = new Vector2(sVal, lt.sizeDelta.y);
        rt.sizeDelta = new Vector2(sVal, rt.sizeDelta.y);
        tt.sizeDelta = new Vector2(tt.sizeDelta.x, sVal);
        bt.sizeDelta = new Vector2(bt.sizeDelta.x, sVal);
        


    }
}

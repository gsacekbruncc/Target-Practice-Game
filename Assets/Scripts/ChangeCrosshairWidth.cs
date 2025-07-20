using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCrosshairWidth : MonoBehaviour
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

        lt.sizeDelta = new Vector2(lt.sizeDelta.x, sVal);
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, sVal);
        tt.sizeDelta = new Vector2(sVal, tt.sizeDelta.y);
        bt.sizeDelta = new Vector2(sVal, bt.sizeDelta.y);
        


    }
}

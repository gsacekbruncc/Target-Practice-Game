using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshairGreen : MonoBehaviour
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
        var lt = (Color32)leftTick.color;
        var rt = (Color32)rightTick.color;
        var tt = (Color32)topTick.color;
        var bt = (Color32)bottomTick.color;

        var sVal = (byte)slider.value;

        lt.g = sVal;
        rt.g = sVal;
        tt.g = sVal;
        bt.g = sVal;

        leftTick.color = lt;
        rightTick.color = rt;
        topTick.color = tt;
        bottomTick.color = bt;
    }
}

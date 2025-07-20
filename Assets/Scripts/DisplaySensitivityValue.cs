using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DisplaySensitivityValue : MonoBehaviour
{
    public Slider slider;

    TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = slider.value.ToString("0.00");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sensitivity;
    public GameObject crosshairLength;
    public GameObject crosshairWidth;
    public GameObject crosshairSpread;
    public GameObject crosshairRed;
    public GameObject crosshairGreen;
    public GameObject crosshairBlue;
    public GameObject settingsParent;

    bool saved;

    void Start()
    {
        saved = false;
        settingsParent.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(saved == false)
        {
            Slider sensitivitySlider = sensitivity.GetComponent<Slider>();
            
            Slider crosshairLengthSlider = crosshairLength.GetComponent<Slider>();
            Slider crosshairWidthSlider = crosshairWidth.GetComponent<Slider>();
            Slider crosshairSpreadSlider = crosshairSpread.GetComponent<Slider>();
            
            Slider crosshairRedSlider = crosshairRed.GetComponent<Slider>();
            Slider crosshairGreenSlider = crosshairGreen.GetComponent<Slider>();
            Slider crosshairBlueSlider = crosshairBlue.GetComponent<Slider>();

            sensitivitySlider.value = SaveManager.GetSensitivity();
            
            crosshairLengthSlider.value = SaveManager.GetCrosshairLength();
            crosshairWidthSlider.value = SaveManager.GetCrosshairWidth();
            crosshairSpreadSlider.value = SaveManager.GetCrosshairSpread();
            
            crosshairRedSlider.value = SaveManager.GetCrosshairRed();
            crosshairGreenSlider.value = SaveManager.GetCrosshairGreen();
            crosshairBlueSlider.value = SaveManager.GetCrosshairBlue();

            settingsParent.gameObject.SetActive(false);
            saved = true;
        }
    }
}

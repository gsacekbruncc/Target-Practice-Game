using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookCharacter : MonoBehaviour
{

    public float lookSpeed = 1f;
    float pitch = 0f;
    public Transform playerBody;
    public Slider sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity.onValueChanged.AddListener(OnSensitivityChanged);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        playerBody.Rotate(Vector3.up * mouseX, Space.Self);
        
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
        transform.localEulerAngles = Vector3.right * pitch;
        
    }

    public void OnSensitivityChanged(float sensitivity)
    {
        lookSpeed = sensitivity;
    }
}

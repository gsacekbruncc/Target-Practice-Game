using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    float shootTime;
    [SerializeField]
    float time;
    float tTime;
    GameObject gameHandler;
    Renderer rend;
    Color orange = new Color(1f, 1f, 0f);
    Color red = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        tTime = 2;
        rend = GetComponent<Renderer>();
        gameHandler = GameObject.Find("Game Handler");
        shootTime = gameHandler.GetComponent<LevelManager>().GetShootTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("TutorialLaser"))
        {
            if(tTime <= 0)
            {
                tTime = 2;
            }
            tTime -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp01(tTime / shootTime);
            rend.material.color = Color.Lerp(orange, red, 1f - normalizedValue);
            rend.material.SetColor("_EmissionColor", Color.Lerp(orange, red, 1f - normalizedValue));
        }
        else
        {
            var normalizedValue = Mathf.Clamp01(time / shootTime);
            rend.material.color = Color.Lerp(orange, red, 1f - normalizedValue);
            rend.material.SetColor("_EmissionColor", Color.Lerp(orange, red, 1f - normalizedValue));
        }
        
    }

    public void SetTime(float time)
    {
        this.time = time;
    }
}

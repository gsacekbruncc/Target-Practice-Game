using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject jumpPad;
    public float zPosOff;
    public float zPosOn;

    float liveTime;
    float respawnTime;
    bool touching;
    bool active;
    LevelManager LevelManager;
    Renderer rend;
    Collider platCollider;
    Collider areaCollider;
    Collider jumpPadCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.Find("Game Handler").GetComponent<LevelManager>();
        touching = false;
        liveTime = 2;
        rend = platform.gameObject.GetComponent<Renderer>();
        platCollider = platform.gameObject.GetComponent<Collider>();
        jumpPadCollider = jumpPad.gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        var inChallenge = LevelManager.GetInChallenge();

        if(!inChallenge)
        {
            active = false;
            liveTime = 2;
            respawnTime = 0;
            platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, zPosOff);
        }
        else
        {
            active = true;
            if(touching && LevelManager.GetInRound() == true)
            {
                liveTime -= Time.deltaTime;
            }

            if(liveTime <= 0)
            {   
                platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, zPosOff);
                touching = false;
                liveTime = 2;
                respawnTime = 3;
                Debug.Log("Set respawnTime: " + respawnTime);
            }

            if(respawnTime > 0)
            {
                respawnTime -= Time.deltaTime;
                Debug.Log(respawnTime);
            }

            if(respawnTime <= 0)
            {
                platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, zPosOn);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().CompareTag("Player"))
        {
            touching = true;
        }
        
    }   
    void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<Collider>().CompareTag("Player"))
        {
            touching = false;
            liveTime = 2;
        }
    }

    public bool GetActive()
    {
        return active;
    }

}

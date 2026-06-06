using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    LevelManager LevelManager;
    SetCameraPosition SetCameraPosition;
    AudioSource source;
    AudioClip deathAudio;
    GameObject player;
    GameObject gameHandler;
    

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Game Handler");
        LevelManager = gameHandler.GetComponent<LevelManager>();
        SetCameraPosition = gameHandler.GetComponent<SetCameraPosition>();
        player = GameObject.Find("Player");
        source = player.GetComponent<AudioSource>();
        source.clip = Resources.Load<AudioClip>("Death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.collider.CompareTag("Player"))
        {
            source.Play();
            source.time = .2f;

            SetCameraPosition.ResetCamera();
            
            LevelManager.CancelGameMode();    
        }  
    }
}

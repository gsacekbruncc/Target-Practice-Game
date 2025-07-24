using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameModeManager : MonoBehaviour
{
    public GameObject[] gameModes;
    public GameObject startTarget;

    int gameMode;
    Camera cam;
    //bool roundStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameMode = 0;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            var hitInfo = Physics.Raycast(ray, out var hit);
            var modeButton = hit.collider.gameObject;

            if(hitInfo && gameModes.Contains(hit.collider.gameObject))
            {
                if(modeButton == gameModes[0])
                {
                    GetComponent<SpawnTarget>().StartTutorial();
                }
            }
        }
    }
}

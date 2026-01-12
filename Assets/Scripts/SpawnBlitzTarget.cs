using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlitzTarget : MonoBehaviour
{
    GameObject target;
    GameObject GameHandler;


    // Start is called before the first frame update
    void Start()
    {
        GameHandler = GameObject.Find("Game Handler");
        target = GameObject.Find("Target");
    }


}

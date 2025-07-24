using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextInactiveMovingTargets : MonoBehaviour
{
    public GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targets[0].activeInHierarchy == false && targets[1].activeInHierarchy == false)
        {
            gameObject.SetActive(false);
        }
    }
}

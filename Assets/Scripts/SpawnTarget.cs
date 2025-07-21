using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public float interval;
    public float liveTime;
    public float zPosition;
    public float startDelay;
    public float roundTime;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        roundTime += startDelay;
        InvokeRepeating(nameof(Spawn), startDelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        if(roundTime > 0)
        {
            roundTime -= Time.deltaTime;
        }
        else
        {  
            //CancelInvoke() stops all invokes
            CancelInvoke(nameof(Spawn));
        }
    }

    void Spawn()
    {
        var x = Random.Range(-10f, 10f);
        var y = Random.Range(target.transform.localScale.y, 5f);
        var position = new Vector3(x, y, zPosition);

        Instantiate(target, position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float dx;
    public float speed;
    public int presetDirection;

    Vector3 origin;
    int direction;


    // Start is called before the first frame update
    void Start()
    {   
        direction = Random.Range(0,2);
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(presetDirection == 0)
        {
            if(direction == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x + dx, origin.y, origin.z), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, origin.y + dx, origin.z), speed * Time.deltaTime);        
            }
        }
        else
        {
            if(presetDirection == -1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x + dx, origin.y, origin.z), speed * Time.deltaTime);
            }
            if(presetDirection == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(origin.x, origin.y + dx, origin.z), speed * Time.deltaTime);
            }
        }
        
        if(transform.position == new Vector3(origin.x + dx, origin.y, origin.z) 
        || transform.position == new Vector3(origin.x - dx, origin.y, origin.z) 
        || transform.position == new Vector3(origin.x, origin.y + dx, origin.z) 
        || transform.position == new Vector3(origin.x, origin.y - dx, origin.z))
        {
            dx *= -1;
        }
    }
}

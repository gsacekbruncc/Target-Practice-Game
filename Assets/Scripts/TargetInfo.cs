using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInfo : MonoBehaviour
{
    public int stillPoints;
    public int movingPoints;
    public int hostilePoints;
    
    int points;
    int bonusPoints;
    float time;
    string type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bonusPoints = Mathf.FloorToInt(50f / time);
        if(type == null)
        {
            if(GetComponent<MoveTarget>() == null
            && GetComponent<ShootPlayer>() == null)
            {
                type = "still";
            }
            if(GetComponent<MoveTarget>() != null)
            {
                type = "moving";
            }
            if(GetComponent<ShootPlayer>() != null)
            {
                type = "hostile";
            }
        }
        if(type == "still")
        {
            points = stillPoints + bonusPoints;
        }
        if(type == "moving")
        {
            points = movingPoints + bonusPoints;
        }
        if(type == "hostile")
        {
            points = hostilePoints + bonusPoints;
        }
    }

    public int GetPoints()
    {
        return points;
    }
    public float GetTTH()
    {
        return time;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float time;

    bool laserSpawned;
    GameObject player;
    GameObject laserPrefab;
    GameObject newLaser;

    // Start is called before the first frame update
    void Start()
    {
        //player = Camera.main;
        player = GameObject.Find("Player");
        laserPrefab = GameObject.Find("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(!laserSpawned)
        {
            newLaser = Instantiate(laserPrefab, transform.position, transform.rotation);
            newLaser.AddComponent<ChangeColor>();
            laserSpawned = true;
        }
        else
        {   
            newLaser.GetComponent<ChangeColor>().SetTime(time);
            var tp = newLaser.transform.position;
            var ls = newLaser.transform.localScale;

            var dist = Vector3.Distance(player.transform.position, transform.position);
            var direction = (player.transform.position - transform.position).normalized;
            var newPosition = new Vector3(dist, tp.y, tp.z);
            ls.y = dist;
            
            //newLaser.transform.position = newPosition;
            newLaser.transform.localScale = ls;
            newLaser.transform.up = direction;
            //transform.rotation = Quaternion.LookRotation(direction);
        }

        if(time <= 0 && gameObject.CompareTag("Target"))
        {
            Ray ray = new Ray(newLaser.transform.position, newLaser.transform.up);
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100);
            if(Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.gameObject.name == "Player")
                {
                    var gameHandler = GameObject.Find("Game Handler");
                    gameHandler.GetComponent<LevelManager>().SetInRound(false);
                }
            }
        }

        if(gameObject.CompareTag("TutorialTarget"))
        {
            newLaser.tag = "TutorialLaser";
        }
    }

    void OnDestroy()
    {
        Destroy(newLaser);
    }

    void OnDisable()
    {
        Destroy(newLaser);
        laserSpawned = false;
    }
}

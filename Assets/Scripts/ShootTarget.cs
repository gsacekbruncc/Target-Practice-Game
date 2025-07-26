using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{

    public float rayDistance = 100;

    GameObject gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Game Handler");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameHandler.GetComponent<LevelManager>().IncShotsFired();

            Ray ray = new Ray(transform.position, transform.forward);
            //Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 100);

            if(Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                var target = hit.collider.gameObject;
                if(target.CompareTag("TutorialTarget"))
                {
                    target.SetActive(false);
                }
                else if(target.CompareTag("Target"))
                {
                    gameHandler.GetComponent<LevelManager>().IncTTTH(target.GetComponent<TargetInfo>().GetTTH());
                    gameHandler.GetComponent<LevelManager>().IncScore(target.GetComponent<TargetInfo>().GetPoints());
                    gameHandler.GetComponent<LevelManager>().IncTargetsHit();
                    gameHandler.GetComponent<LevelManager>().RemoveLiveTarget(target);
                    Destroy(target);
                }
            }
        }
    }   
}

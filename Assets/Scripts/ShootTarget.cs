using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{

    public float rayDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void shoot()
    {
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
                GameObject.Find("Game Handler").GetComponent<SpawnTarget>().removeLiveTarget(target);
                Destroy(target);
            }
            
        }
    }
    
}

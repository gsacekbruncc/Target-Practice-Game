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
            if(hit.collider.gameObject.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
            }
            if(hit.collider.gameObject.CompareTag("TutorialTarget"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
    
}

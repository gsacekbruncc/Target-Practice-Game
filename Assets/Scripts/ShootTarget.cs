using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootTarget : MonoBehaviour
{
    public AudioClip fireSoundClip;
    public AudioClip hitSoundClip;
    public AudioClip clickSoundClip;
    public AudioClip lockedSoundClip;
    public GameObject startTarget;

    float rayDistance = 100;
    float bulletRadius = .05f;
    GameObject target;
    AudioSource fireSoundSource;
    AudioSource playerSoundSource;
    GameObject gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        fireSoundSource = GameObject.Find("AK 47").GetComponent<AudioSource>();
        playerSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();
        gameHandler = GameObject.Find("Game Handler");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            gameHandler.GetComponent<LevelManager>().IncShotsFired();
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 100); 
            
            if(Physics.SphereCast(ray, bulletRadius, out RaycastHit hit, rayDistance))
            {
                target = hit.collider.gameObject;
                //Debug.Log(target.name);

                if(target.CompareTag("Button") || target.CompareTag("Slider") || target.CompareTag("IncrementSensitivity") || target.CompareTag("DecrementSensitivity"))
                {
                    if(target.transform.parent.name == "Game Modes" || target.transform.parent.name == "Blitz Menu")
                    {
                        if(SaveManager.IsLevelUnlockedString(target.name))
                        {
                            playerSoundSource.PlayOneShot(hitSoundClip, .5f);
                        }
                        else
                        {
                            playerSoundSource.PlayOneShot(lockedSoundClip, .2f);
                        }
                    }
                    else if(!target.CompareTag("Slider") || target.name == "Blitz")
                    {
                        playerSoundSource.PlayOneShot(clickSoundClip, .1f);
                    }
                }
                else
                {
                    fireSoundSource.PlayOneShot(fireSoundClip, .2f);
                    if(target.CompareTag("TutorialTarget"))
                    {
                        playerSoundSource.PlayOneShot(hitSoundClip, .5f);
                        startTarget.SetActive(false);
                        target.SetActive(false);
                    }
                    if(target.CompareTag("Target"))
                    {
                        bool blitz = target.GetComponent<TargetInfo>().IsBlitzTarget();
                        if(blitz)
                        {
                            gameHandler.GetComponent<LevelManager>().Spawn();
                        }

                        playerSoundSource.PlayOneShot(hitSoundClip, .5f);
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
    public GameObject GetTarget()
    {
        return target;
    } 
}

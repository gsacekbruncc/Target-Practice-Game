using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootTarget : MonoBehaviour
{
    public AudioClip fireSoundClip;
    public AudioClip hitSoundClip;
    public float rayDistance = 100;

    AudioSource fireSoundSource;
    AudioSource hitSoundSource;
    GameObject gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        fireSoundSource = GameObject.Find("AK 47").GetComponent<AudioSource>();
        hitSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();
        gameHandler = GameObject.Find("Game Handler");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fireSoundSource.PlayOneShot(fireSoundClip, .5f);

            gameHandler.GetComponent<LevelManager>().IncShotsFired();

            Ray ray = new Ray(transform.position, transform.forward);
            //Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 100);


            if(Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                var target = hit.collider.gameObject;

                if(target.CompareTag("Button"))
                {
                    hitSoundSource.PlayOneShot(hitSoundClip, .5f);
                }

                if(target.CompareTag("TutorialTarget"))
                {
                    hitSoundSource.PlayOneShot(hitSoundClip, .5f);
                    target.SetActive(false);
                }
                else if(target.CompareTag("Target"))
                {
                    hitSoundSource.PlayOneShot(hitSoundClip, .5f);
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

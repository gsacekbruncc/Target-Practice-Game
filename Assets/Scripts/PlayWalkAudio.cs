using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkAudio : MonoBehaviour
{
    public AudioClip[] clips;

    AudioSource playerSource;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        playerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(time);
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if(!playerSource.isPlaying && GetComponent<MoveCharacter>().GetIsJumpable() == true)
            {
                var num = Random.Range(0, clips.Length - 1);
                playerSource.PlayOneShot(clips[num], .3f);
            }
            time += Time.deltaTime;
        }
        // else
        // {
        //     time = 0f;
        // }

        // if(time <= 0 && !playerSource.isPlaying)
        // {
        //     time = .4f;
        //     var num = Random.Range(0, clips.Length - 1);
        //     playerSource.PlayOneShot(clips[num], .3f);
        // }

    }
}

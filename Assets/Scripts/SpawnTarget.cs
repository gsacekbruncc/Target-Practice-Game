using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnTarget : MonoBehaviour
{
    public float interval;
    public float zPosition;
    public float startDelay;
    public float roundTime;
    public float liveTime;
    public float shootTime;
    public GameObject target;
    public GameObject[] tutorialTargets;

    List<GameObject> liveTargets = new List<GameObject>();
    bool inRound;
    bool inTutorial;
    bool inFreePlay;

    int tutorialStage;


    // Start is called before the first frame update
    void Start()
    {
        inTutorial = false;
        inRound = false;
        roundTime += startDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if(!inTutorial)
        {
            for(int i = 0; i < tutorialTargets.Length; i++)
            {
                if(tutorialTargets[i].activeInHierarchy == true)
                {
                    tutorialTargets[i].SetActive(false);
                } 
            }
            tutorialStage = 0;
        }
        if(inTutorial)
        {
            inFreePlay = false;
            //Stage 1
            if(tutorialStage == 0 && tutorialTargets[0].activeInHierarchy == false)
            {
                tutorialTargets[0].SetActive(true);
                tutorialStage = 1;             
            }
            //Stage 2
            if(tutorialStage == 1 && tutorialTargets[0].activeInHierarchy == false 
            && tutorialTargets[1].activeInHierarchy == false
            && tutorialTargets[2].activeInHierarchy == false)
            {
                tutorialTargets[1].SetActive(true);
                tutorialTargets[2].SetActive(true);
                tutorialStage = 2;
            }
            //Stage 3
            if(tutorialStage == 2 && tutorialTargets[0].activeInHierarchy == false 
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false
            && tutorialTargets[3].activeInHierarchy == false)
            {
                tutorialTargets[3].SetActive(true);
                tutorialStage = 3;
            }
            //Stage 4
            if(tutorialStage == 3 && tutorialTargets[0].activeInHierarchy == false 
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false 
            && tutorialTargets[3].activeInHierarchy == false
            && tutorialTargets[4].activeInHierarchy == false)
            {
                tutorialTargets[4].SetActive(true);
                tutorialStage = 4;
            }
            //Stage 5
            if(tutorialStage == 4 && tutorialTargets[0].activeInHierarchy == false 
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false 
            && tutorialTargets[3].activeInHierarchy == false
            && tutorialTargets[4].activeInHierarchy == false
            && tutorialTargets[5].activeInHierarchy == false)
            {
                tutorialTargets[5].SetActive(true);
                tutorialStage = 5;
            }
            //End Tutorial
            if(tutorialStage == 5 && tutorialTargets[0].activeInHierarchy == false
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false 
            && tutorialTargets[3].activeInHierarchy == false
            && tutorialTargets[4].activeInHierarchy == false
            && tutorialTargets[5].activeInHierarchy == false)
            {
                inTutorial = false;
            }
        }
        if(!inRound)
        {
            CancelInvoke(nameof(Spawn));
            inTutorial = false;
            inFreePlay = false;
            foreach(GameObject target in liveTargets)
            {
                Destroy(target);
            }
        }

        // else if(inRound || inFreePlay)
        // {
        //     if(roundTime > 0)
        //     {
        //         roundTime -= Time.deltaTime;
        //     }
        //     else
        //     {  
        //         //CancelInvoke() stops all invokes
        //         CancelInvoke(nameof(Spawn));
        //     }
        // }
        // else
        // {
        //     CancelInvoke(nameof(Spawn));
        // }
    }

    void Spawn()
    {
        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(target.transform.localScale.y, 5f), zPosition);
        var type = Random.Range(0, 3);
        
        var newTarget = Instantiate(target, position, Quaternion.identity);

        var dTime = newTarget.AddComponent<DespawnTarget>();
        dTime.liveTime = liveTime;
        
        if(type == 1)
        {
            var mt = newTarget.AddComponent<MoveTarget>(); 
            mt.dx = 2;
            mt.speed = 2;
        }
        if(type == 2)
        {
            var st = newTarget.AddComponent<ShootPlayer>();
            st.time = shootTime;
        }  
        liveTargets.Add(newTarget);
    }

    public void setInRound(bool status)
    {   
        inRound = status;
    }
    
    public void removeLiveTarget(GameObject target)
    {
        liveTargets.Remove(target);
    }

    void StartRound()
    {
        InvokeRepeating(nameof(Spawn), startDelay, interval);
        inRound = true;
    }
    public void StartTutorial()
    {
        CancelInvoke(nameof(Spawn));
        foreach(GameObject target in liveTargets)
        {
            Destroy(target);
        }
        inTutorial = true;
        inRound = true;
        inFreePlay = false;
    }
    public void StartFreePlay()
    {
        CancelInvoke(nameof(Spawn));
        InvokeRepeating(nameof(Spawn), startDelay, interval);
        inFreePlay = true;
        inRound = true;
        inTutorial = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public float interval;
    public float zPosition;
    public float startDelay;
    public float roundTime;
    public float liveTime;
    public GameObject target;
    public GameObject[] tutorialTargets;

    bool inTutorial;
    int tutorialStage;
    bool inRound;

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

        if(inTutorial)
        {
            if(tutorialStage == 0 && tutorialTargets[0].activeInHierarchy == false && tutorialTargets[1].activeInHierarchy == false && tutorialTargets[2].activeInHierarchy == false)
            {
                tutorialTargets[0].SetActive(true);
                tutorialStage = 1;             
            }
            if(tutorialStage == 1 && tutorialTargets[0].activeInHierarchy == false && tutorialTargets[2].activeInHierarchy == false)
            {
                tutorialTargets[1].SetActive(true);
                tutorialStage = 2;
            }
            if(tutorialStage == 2 && tutorialTargets[1].activeInHierarchy == false && tutorialTargets[0].activeInHierarchy == false)
            {
                tutorialTargets[2].SetActive(true);
                tutorialStage = 3;
            }
            if(tutorialStage == 3)
            {
                inTutorial = false;
            }
        }
        else if(inRound)
        {
            if(roundTime > 0)
            {
                roundTime -= Time.deltaTime;
            }
            else
            {  
                //CancelInvoke() stops all invokes
                CancelInvoke(nameof(Spawn));
            }
        }
    }

    void Spawn()
    {
        //var x = Random.Range(-10f, 10f);
        //var y = Random.Range(target.transform.localScale.y, 5f);
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
            st.time = 5;
        }  
    }

    void StartRound()
    {
        InvokeRepeating(nameof(Spawn), startDelay, interval);
        inRound = true;
    }

    public void StartTutorial()
    {
        inTutorial = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    
    //public float targetValue;
    public GameObject startTarget;
    public GameObject target;
    public GameObject results;
    public GameObject lava;
    public GameObject[] tutorialTargets;
    public GameObject[] levelText;
    public GameObject[] platforms;

    List<GameObject> liveTargets = new List<GameObject>();
    GameObject spawnPlane;
    MoveTarget moveTarget;
    ShootPlayer shootPlayer;
    bool inRound;
    bool inTutorial;
    bool inEasy;
    bool inMedium;
    bool inHard;
    bool inChallenge;
    bool inFreePlay;
    int targetsSpawned;
    int tutorialStage;
    int targetType;
    int targetsHit;
    int shotsFired;
    float score;
    float tTTH;
    float interval;
    float startDelay;
    float roundTime;
    float liveTime;
    float shootTime;
    float moveDelta;
    float moveSpeed;
    float zPosOff;
    float zPosOn;
    string accuracy;
    string mode;
    string level;
    string aTTH;

    // Start is called before the first frame update
    void Start()
    {

        zPosOff = GameObject.Find("Area Collider Small").GetComponent<PlatformManager>().zPosOff;
        zPosOn = GameObject.Find("Area Collider Small").GetComponent<PlatformManager>().zPosOn;
        moveTarget = GetComponent<MoveTarget>();
        shootPlayer = GetComponent<ShootPlayer>();
        roundTime += startDelay;
        spawnPlane = GameObject.Find("Spawn Plane");
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
            inRound = true;
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
                shootTime = 2;
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
            //Stage 6
            if(tutorialStage == 5 && tutorialTargets[0].activeInHierarchy == false 
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false 
            && tutorialTargets[3].activeInHierarchy == false
            && tutorialTargets[4].activeInHierarchy == false
            && tutorialTargets[5].activeInHierarchy == false
            && tutorialTargets[6].activeInHierarchy == false)
            {
                tutorialTargets[6].SetActive(true);
                tutorialStage = 6;
            }
            //End Tutorial
            if(tutorialStage == 6 && tutorialTargets[0].activeInHierarchy == false
            && tutorialTargets[1].activeInHierarchy == false 
            && tutorialTargets[2].activeInHierarchy == false 
            && tutorialTargets[3].activeInHierarchy == false
            && tutorialTargets[4].activeInHierarchy == false
            && tutorialTargets[5].activeInHierarchy == false
            && tutorialTargets[6].activeInHierarchy == false)
            {
                inTutorial = false;
            }
        }
        if(inEasy)
        {   
            if(inRound)
            {
                roundTime -= Time.deltaTime;
                if(roundTime <= 0)
                {
                    CancelInvoke(nameof(Spawn));
                    foreach(GameObject target in liveTargets)
                    {
                        Destroy(target);
                    }
                    if(targetsHit > 0)
                    {
                        accuracy = ((float)targetsHit / shotsFired * 100).ToString("00.00");
                        aTTH = Mathf.RoundToInt((float)tTTH / targetsHit * 100).ToString();
                    }
                    else
                    {
                        accuracy = "N/A";
                        aTTH = "N/A";
                    }
                    GetComponent<DisplayResults>().setValue(mode, level, score.ToString(), targetsHit.ToString(), aTTH.ToString(), accuracy.ToString());
                    results.SetActive(true);
                    
                    inRound = false;
                    if(level != "3")
                    {
                        levelText[int.Parse(level) - 1].SetActive(false);
                        levelText[int.Parse(level)].SetActive(true);
                        startTarget.SetActive(true);
                    }
                    if(level == "3")
                    {
                        inEasy = false;
                    }
                } 
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "0")
            {   
                level = "1";
                inRound = true;
                targetType = 0;
                interval = 3;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);

                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "1")
            {   
                levelText[0].SetActive(false);
                levelText[1].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "2";
                inRound = true;
                targetType = 0;
                interval = 1.5f;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "2")
            {   
                levelText[1].SetActive(false);
                levelText[2].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "3";
                inRound = true;
                targetType = 0;
                interval = .75f;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
        }
        if(inMedium)
        {   
            if(inRound)
            {
                roundTime -= Time.deltaTime;
                if(roundTime <= 0)
                {
                    CancelInvoke(nameof(Spawn));
                    foreach(GameObject target in liveTargets)
                    {
                        Destroy(target);
                    }
                    if(targetsHit > 0)
                    {
                        accuracy = ((float)targetsHit / shotsFired * 100).ToString("00.00");
                        aTTH = Mathf.RoundToInt((float)tTTH / targetsHit * 100).ToString();
                    }
                    else
                    {
                        accuracy = "N/A";
                        aTTH = "N/A";
                    }
                    GetComponent<DisplayResults>().setValue(mode, level, score.ToString(), targetsHit.ToString(), aTTH.ToString(), accuracy.ToString());
                    results.SetActive(true);
                    
                    inRound = false;
                    if(level != "3")
                    {
                        levelText[int.Parse(level) - 1].SetActive(false);
                        levelText[int.Parse(level)].SetActive(true);
                        startTarget.SetActive(true);
                    }
                    if(level == "3")
                    {
                        inMedium = false;
                    }
                } 
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "0")
            {   
                level = "1";
                inRound = true;
                targetType = 1;
                moveDelta = 1;
                moveSpeed = 2;
                interval = 2;
                liveTime = 2;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);

                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "1")
            {   
                levelText[0].SetActive(false);
                levelText[1].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "2";
                inRound = true;
                targetType = 1;
                moveDelta = 2;
                moveSpeed = 3;
                interval = 1;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "2")
            {   
                levelText[1].SetActive(false);
                levelText[2].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "3";
                inRound = true;
                targetType = 1;
                moveDelta = 3;
                moveSpeed = 4;
                interval = .75f;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
        }
        if(inHard)
        {   
            if(inRound)
            {
                roundTime -= Time.deltaTime;
                if(roundTime <= 0)
                {
                    CancelInvoke(nameof(Spawn));
                    foreach(GameObject target in liveTargets)
                    {
                        Destroy(target);
                    }
                    if(targetsHit > 0)
                    {
                        accuracy = ((float)targetsHit / shotsFired * 100).ToString("00.00");
                        aTTH = Mathf.RoundToInt((float)tTTH / targetsHit * 100).ToString();
                    }
                    else
                    {
                        accuracy = "N/A";
                        aTTH = "N/A";
                    }
                    GetComponent<DisplayResults>().setValue(mode, level, score.ToString(), targetsHit.ToString(), aTTH.ToString(), accuracy.ToString());
                    results.SetActive(true);
                    
                    inRound = false;
                    if(level != "3")
                    {
                        levelText[int.Parse(level) - 1].SetActive(false);
                        levelText[int.Parse(level)].SetActive(true);
                        startTarget.SetActive(true);
                    }
                    if(level == "3")
                    {
                        inHard = false;
                    }
                } 
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "0")
            {   
                level = "1";
                inRound = true;
                targetType = 2;
                shootTime = 1.9f;
                moveDelta = 2;
                moveSpeed = 3;
                interval = 2;
                liveTime = 2;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);

                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "1")
            {   
                levelText[0].SetActive(false);
                levelText[1].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "2";
                inRound = true;
                targetType = 2;
                shootTime = 1;
                moveDelta = 2;
                moveSpeed = 3;
                interval = 1;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "2")
            {   
                levelText[1].SetActive(false);
                levelText[2].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "3";
                inRound = true;
                targetType = 2;
                moveDelta = 3;
                moveSpeed = 4;
                interval = .75f;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
        }
        if(inChallenge)
        {   
            if(inRound)
            {
                roundTime -= Time.deltaTime;
                if(roundTime <= 0)
                {
                    lava.SetActive(false);
                    CancelInvoke(nameof(Spawn));
                    foreach(GameObject target in liveTargets)
                    {
                        Destroy(target);
                    }
                    if(targetsHit > 0)
                    {
                        accuracy = ((float)targetsHit / shotsFired * 100).ToString("00.00");
                        aTTH = Mathf.RoundToInt((float)tTTH / targetsHit * 100).ToString();
                    }
                    else
                    {
                        accuracy = "N/A";
                        aTTH = "N/A";
                    }
                    GetComponent<DisplayResults>().setValue(mode, level, score.ToString(), targetsHit.ToString(), aTTH.ToString(), accuracy.ToString());
                    results.SetActive(true);
                    
                    inRound = false;
                    if(level != "3")
                    {
                        levelText[int.Parse(level) - 1].SetActive(false);
                        levelText[int.Parse(level)].SetActive(true);
                        startTarget.SetActive(true);
                    }
                    if(level == "3")
                    {
                        inHard = false;
                    }
                } 
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "0")
            {   
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "1";
                inRound = true;
                targetType = 0;
                interval = 1.5f;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                lava.SetActive(true);

                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "1")
            {   
                levelText[0].SetActive(false);
                levelText[1].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "2";
                inRound = true;
                targetType = 1;
                moveDelta = 2;
                moveSpeed = 3;
                interval = 1;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                lava.SetActive(true);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
            if(!inRound && startTarget.activeInHierarchy == false && level == "2")
            {   
                levelText[1].SetActive(false);
                levelText[2].SetActive(true);
                tTTH = 0;
                score = 0;
                targetsHit = 0;
                shotsFired = 0;        
                level = "3";
                inRound = true;
                targetType = 2;
                shootTime = 1;
                moveDelta = 2;
                moveSpeed = 3;
                interval = 1;
                liveTime = 3;
                roundTime = 30;
                targetsSpawned = Mathf.FloorToInt(roundTime / interval);
                lava.SetActive(true);
                
                InvokeRepeating(nameof(Spawn), 0f, interval);
            }
        }
        if(!inRound)
        {
            CancelInvoke(nameof(Spawn));
            foreach(GameObject target in liveTargets)
            {
                Destroy(target);
            }
        }
    }

    void Spawn()
    {

        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(target.transform.localScale.y, 5f), spawnPlane.transform.position.z);
        
        var newTarget = Instantiate(target, position, Quaternion.identity);

        var dTime = newTarget.AddComponent<DespawnTarget>();
        dTime.liveTime = liveTime;
        
        if(targetType == 1)
        {
            var typeComp = Random.Range(0, 3);
            if(level == "2")
            {
                typeComp = Random.Range(0, 2);
            }
            if(level == "3")
            {
                typeComp = 0;
            }
            if(level is "1" or "3" && typeComp is 0)
            {
                var mt = newTarget.AddComponent<MoveTarget>(); 
                mt.dx = moveDelta;
                mt.speed = moveSpeed;
            }
            else if(level == "2" && typeComp is 1 or 2)
            {
                var mt = newTarget.AddComponent<MoveTarget>(); 
                mt.dx = moveDelta;
                mt.speed = moveSpeed;
            }
        }
        if(targetType == 2)
        {
            var typeComp = Random.Range(0, 3);
            if(level == "1")
            {
                if(typeComp is 0 or 1)
                {
                    var mt = newTarget.AddComponent<MoveTarget>(); 
                    mt.dx = moveDelta;
                    mt.speed = moveSpeed;
                }
                else
                {
                    var st = newTarget.AddComponent<ShootPlayer>();
                    st.time = shootTime;
                }
            }
            else
            {
                typeComp = Random.Range(0, 2);
                if(typeComp == 0)
                {
                    var mt = newTarget.AddComponent<MoveTarget>(); 
                    mt.dx = moveDelta;
                    mt.speed = moveSpeed;
                }
                else
                {
                    var st = newTarget.AddComponent<ShootPlayer>();
                    st.time = shootTime;
                }
            }
        }  
        liveTargets.Add(newTarget);
    }

    public void SetInRound(bool status)
    {   
        inRound = status;
    }
    
    public void CancelGameMode()
    {   
        CancelInvoke(nameof(Spawn));
        foreach(GameObject target in liveTargets)
        {
            Destroy(target);
        }
        foreach(GameObject text in levelText)
        {
            text.SetActive(false);
        }
        foreach(GameObject platform in platforms)     
        {
            var pos = platform.transform.position;
            pos = new Vector3(pos.x, pos.y, zPosOff);
        }   
        lava.SetActive(false);
        inTutorial = false;
        inEasy = false;
        inMedium = false;
        inHard = false;
        inChallenge = false;
        inFreePlay = false;
    }

    public void RemoveLiveTarget(GameObject target)
    {
        liveTargets.Remove(target);
    }

    public void IncTargetsHit()
    {
        targetsHit++;
    }
    public void IncScore(int score)
    {
        this.score += score;
    }
    public void IncTTTH(float tTH)
    {
        this.tTTH += tTH;
    }
    public void IncShotsFired()
    {
        shotsFired++;
    }

    public int GetTargetsSpawned()
    {
        return targetsSpawned;
    }
    public float GetShootTime()
    {
        return shootTime;
    }
    public bool GetInChallenge()
    {
        return inChallenge;
    }
    public bool GetInRound()
    {
        return inRound;
    }

    
    public void StartTutorial()
    {
        CancelGameMode();
        level = "0";
        tTTH = 0;
        score = 0;
        targetsHit = 0;
        shotsFired = 0;
        mode = "Tutorial";
        inRound = false;
        inTutorial = true;
        startTarget.SetActive(false);
        results.SetActive(false);
    }
    public void StartEasy()
    {
        CancelGameMode();
        level = "0";
        tTTH = 0;
        score = 0;
        targetsHit = 0;
        shotsFired = 0;
        mode = "Easy";
        inRound = false;
        inEasy = true;
        targetsSpawned = 0;
        startTarget.SetActive(true);
        levelText[0].SetActive(true);
        results.SetActive(false);
    }
    public void StartMedium()
    {
        CancelGameMode();
        level = "0";
        tTTH = 0;
        score = 0;
        targetsHit = 0;
        shotsFired = 0;
        mode = "Medium";
        inRound = false;
        inMedium = true;
        targetsSpawned = 0;
        startTarget.SetActive(true);
        levelText[0].SetActive(true);
        results.SetActive(false);
    }
    public void StartHard()
    {
        CancelGameMode();
        shootTime = 0;
        level = "0";
        tTTH = 0;
        score = 0;
        targetsHit = 0;
        shotsFired = 0;
        mode = "Hard";
        inRound = false;
        inHard = true;
        targetsSpawned = 0;
        startTarget.SetActive(true);
        levelText[0].SetActive(true);
        results.SetActive(false);
    }
    public void StartChallenge()
    {
        CancelGameMode();
        shootTime = 0;
        level = "0";
        tTTH = 0;
        score = 0;
        targetsHit = 0;
        shotsFired = 0;
        mode = "Challenge";
        inRound = false;
        inChallenge = true;
        targetsSpawned = 0;
        startTarget.SetActive(true);
        levelText[0].SetActive(true);
        results.SetActive(false);
        foreach(GameObject platform in platforms)
        {
            var pos = platform.transform.position;
            pos = new Vector3(pos.x, pos.y, zPosOn);
        }
    }
    public void StartFreePlay()
    {
        CancelGameMode();
        InvokeRepeating(nameof(Spawn), startDelay, interval);
        inRound = false;
        inRound = true;
        inFreePlay = true;
    }
    // void StartRound()
    // {
    //     InvokeRepeating(nameof(Spawn), startDelay, interval);
    //     inRound = true;
    // }
}

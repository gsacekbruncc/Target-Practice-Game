using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DisplayResults : MonoBehaviour
{
    public GameObject mode;
    public GameObject level;
    public GameObject score;
    public GameObject targetsHit;
    public GameObject aTTH;
    public GameObject accuracy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setValue(string mode, string level, string score, string targetsHit, string aTTH, string accuracy)
    {
        this.mode.GetComponent<TextMeshProUGUI>().text = mode;
        this.level.GetComponent<TextMeshProUGUI>().text = level;
        this.score.GetComponent<TextMeshProUGUI>().text = score;
        this.targetsHit.GetComponent<TextMeshProUGUI>().text = targetsHit + " / " + GetComponent<LevelManager>().getTargetsSpawned();
        this.aTTH.GetComponent<TextMeshProUGUI>().text = aTTH + " ms";
        this.accuracy.GetComponent<TextMeshProUGUI>().text = accuracy + "%";
    }

}

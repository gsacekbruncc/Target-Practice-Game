using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    Camera cam;
    GameObject button;
    GameObject player;
    Color locked = new Color(118, 118, 118);
    Color unlocked = new Color(255, 255, 255);
    
    public GameObject[] buttons;
    public GameObject[] gameModes;
    public GameObject blitzMenu;
    
    
    


    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("UnlockedLevel", 4);
        PlayerPrefs.Save();


        cam = Camera.main;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject target = cam.GetComponent<ShootTarget>().GetTarget();
            if(buttons.Contains(target))
            {   
                var currButton = target;
                GameObject currSubMenu = currButton.GetComponent<ButtonInfo>().subMenu;
                int currId = currButton.GetComponent<ButtonInfo>().id;
                
                //Clicked Play Button
                if(currId == 1)
                {
                    currSubMenu.SetActive(true);
                }
                //Close meny if Blitz button was pressed and Blitz mode is unlocked
                else if(currId == 4 && SaveManager.IsLevelUnlockedString("Blitz"))
                {
                    buttons[0].GetComponent<ButtonInfo>().subMenu.SetActive(false);
                }
                //Close menu if different button was pressed
                else if(currId != 4 && buttons[0].GetComponent<ButtonInfo>().subMenu.activeInHierarchy)
                {
                    buttons[0].GetComponent<ButtonInfo>().subMenu.SetActive(false);
                }
                //Clicked Settings Button
                if(currId == 2)
                {
                    currSubMenu.SetActive(true);
                }
                else if(buttons[1].GetComponent<ButtonInfo>().subMenu.activeInHierarchy)
                {
                    buttons[1].GetComponent<ButtonInfo>().subMenu.SetActive(false);
                }
                //Clicked Quit Button
                if(currId == 3)
                {
                    #if UNITY_STANDALONE
                        Application.Quit();
                    #endif
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                }
                //Clicked Blitz Button
                if(currId == 4 && SaveManager.IsLevelUnlockedString("Blitz"))
                {
                    currSubMenu.SetActive(true);
                }
                else if(buttons[3].GetComponent<ButtonInfo>().subMenu.activeInHierarchy)
                {
                    buttons[3].GetComponent<ButtonInfo>().subMenu.SetActive(false);
                }
            }
            if(gameModes.Contains(target))
            {
                var modeButton = target;
                
                if(SaveManager.IsLevelUnlockedString(target.name))
                { 
                    cam.GetComponent<LookCharacter>().SetPitch(-2.5f);
                    player.transform.position = new Vector3(0f, .8999f, -6.204f);
                    player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                if(modeButton == gameModes[0])
                {
                    GetComponent<LevelManager>().StartTutorial();
                }
                if(modeButton == gameModes[1] && SaveManager.IsLevelUnlocked(1))
                {
                    GetComponent<LevelManager>().StartEasy();
                }
                if(modeButton == gameModes[2] && SaveManager.IsLevelUnlocked(2))
                {
                    GetComponent<LevelManager>().StartMedium();
                }
                if(modeButton == gameModes[3] && SaveManager.IsLevelUnlocked(3))
                {
                    GetComponent<LevelManager>().StartHard();
                }
                if(modeButton == gameModes[4] && SaveManager.IsLevelUnlocked(4))
                {
                    GetComponent<LevelManager>().StartChallenge();
                }
                if(modeButton == gameModes[5] && SaveManager.IsLevelUnlocked(4))
                {
                    blitzMenu.SetActive(false);
                    buttons[0].GetComponent<ButtonInfo>().subMenu.SetActive(true);
                    GetComponent<LevelManager>().StartBlitzEasy();
                }
                if(modeButton == gameModes[6] && SaveManager.IsLevelUnlocked(4))
                {
                    blitzMenu.SetActive(false);
                    buttons[0].GetComponent<ButtonInfo>().subMenu.SetActive(true);
                    GetComponent<LevelManager>().StartBlitzMedium();
                }
                if(modeButton == gameModes[7] && SaveManager.IsLevelUnlocked(4))
                {
                    blitzMenu.SetActive(false);
                    buttons[0].GetComponent<ButtonInfo>().subMenu.SetActive(true);
                    GetComponent<LevelManager>().StartBlitzHard();
                }
            }
        }
        if(SaveManager.IsLevelUnlocked(1))
        {
            gameModes[1].GetComponent<Image>().color = unlocked;
        }
        if(SaveManager.IsLevelUnlocked(2))
        {
            gameModes[2].GetComponent<Image>().color = unlocked;
        }
        if(SaveManager.IsLevelUnlocked(3))
        {
            gameModes[3].GetComponent<Image>().color = unlocked;
        }
        if(SaveManager.IsLevelUnlocked(4))
        {
            gameModes[4].GetComponent<Image>().color = unlocked;
        }
        if(SaveManager.IsLevelUnlocked(4))
        {
            buttons[3].GetComponent<Image>().color = unlocked;
        }
        
    }
}

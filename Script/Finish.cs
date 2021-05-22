using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{/*
    public LevelData levelData;
    public GameObject Playr;
    public GameObject EndLevelMenu;
    public GameObject OutScoring;
    public GameObject OutScoringRealTime;
    private GameObject Compass;
    public GameObject Circle;
    public Button Pause;
    private int Quantity;
    public Text objective;
    private int MinPrizePlace;
    private PauseMenu pauseMenu;
    private Animation anim; 
    public int scoring = 0;
    public GameObject ErrorInternet;
    void Start()
    {
        Compass = FindObjectsOfType<Compass>()[0].gameObject;
        pauseMenu = FindObjectsOfType<PauseMenu>()[0];
        Pause.interactable = true;
        Quantity = GameObject.FindGameObjectsWithTag("Ename").Length;
        MinPrizePlace = Objective();
        anim = OutScoringRealTime.GetComponent<Animation>();
            ErrorInternet.SetActive(!InternetCheck.CheckConectInternet());
            
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Playr"){
            scoring++;
            Savelevel();
            coll.gameObject.transform.position = gameObject.transform.position;
            if (OutScoringRealTime != null)
            OutScoringRealTime.SetActive(false);
            RanEndLevelMenu();
            CircleProgress();
            Pause.interactable = false;
            
            if (InternetCheck.CheckConectInternet()) 
                AdvertisingAds.StaticShow();
            else 
                ErrorInternet.SetActive(true);
            Camera.main.GetComponent<SnapshotMode>().Init = true;
            Time.timeScale = 0f;
        }
        else if (coll.gameObject.tag == "Ename")
        {
            Destroy(coll.gameObject);
            scoring++;
            if (OutScoringRealTime != null)
            OutScoringRealTime.GetComponent<Text>().text = scoring.ToString(); 
            anim.Play();
        }
       

    }
    void Savelevel()
    {
        var namberLeve = GetNamberScene();
        if (levelData.scoring[namberLeve] == 0 || levelData.scoring[namberLeve] > scoring) 
            levelData.scoring[namberLeve] = scoring;
        levelData.isUnlocked[namberLeve] = true;

        if (scoring <= MinPrizePlace && levelData.nameLavel.Length >= namberLeve+1){
            levelData.isUnlocked[namberLeve+1] = true;
            pauseMenu.NexLevelButton.interactable = true;
            pauseMenu.NexLevelPauseMenu.interactable = true;
        }
       
    }
    public static int GetNamberScene()
    {
        var nameScene = SceneManager.GetActiveScene().name;
        nameScene = nameScene.Substring(5);
        int namberLeve = Int32.Parse(nameScene);
        return namberLeve;
    }
    void RanEndLevelMenu()
    {
        if (EndLevelMenu == null) return;
        EndLevelMenu.SetActive(true);
        OutScoring.GetComponent<Text>().text = scoring.ToString();
       
    }
    void FixedUpdate()
    {
        Vector3 vector = Playr.transform.position - gameObject.transform.position;
        if (vector.magnitude > 12f)
        Compass.SetActive(true);
        else Compass.SetActive(false);
    }
    void CircleProgress()
    {
        float precent = (1f / Quantity) * --scoring;
        Circle.GetComponent<Image>().fillAmount = 1f - precent;
    }
    int Objective()
    {
        var textObjective = levelData.objective[Finish.GetNamberScene()];
        int namber;
        if (textObjective.Contains("|n_")){
            namber = textObjective.LastIndexOf("|n_")+3;
            var r = textObjective;
            namber = Int32.Parse(textObjective.Substring(namber));
            objective.text = r.Substring(0, textObjective.LastIndexOf("|n_")) + namber;
            return namber;
        }
        else return 0;
        
    }
    */

}

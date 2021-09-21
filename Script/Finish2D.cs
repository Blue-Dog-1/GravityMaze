using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Tysseek
{
    public class Finish2D : MonoBehaviour
    {
        public LevelData levelData;
        public GameObject Playr;
        public GameObject EndLevelMenu;
        public TextMeshProUGUI OutScoring;
        public TextMeshProUGUI OutScoringRealTime;
        private GameObject Compass;
        public Image Circle;
        public Button Pause;
        private int Quantity;
        public TextMeshProUGUI objective;
        private int MinPrizePlace;
        //private PauseMenu pauseMenu;
        //private Animation anim; 
        public int scoring = 0;
        public GameObject ErrorInternet;
        float precent;
        bool StartProgressCircle = false;
        public bool _switch;
        void Start()
        {
            Compass = FindObjectsOfType<Compass>()[0].gameObject;
            //pauseMenu = FindObjectsOfType<PauseMenu>()[0];
            Pause.interactable = true;
            Quantity = GameObject.FindGameObjectsWithTag("Ename").Length;
            //anim = OutScoringRealTime.GetComponent<Animation>();
            if (!_switch && !InternetCheck.CheckConectInternet())
            {
                ErrorInternet.SetActive(true);
                var rigitbodys = FindObjectsOfType<Rigidbody2D>();
                foreach (var item in rigitbodys)
                {
                    //item.gravityScale = 0;
                    Destroy(item);
                }
            }

        }
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.name == "Playar")
            {
                Debug.Log("finihs");

                scoring++;
                RanEndLevelMenu();

                precent = 1f - ((1f / Quantity) * --scoring);
                StartProgressCircle = true;


                Savelevel();

                OutScoringRealTime.gameObject.SetActive(false);
                /*
                coll.gameObject.transform.position = gameObject.transform.position;

                */
                Pause.interactable = false;
                if (InternetCheck.CheckConectInternet())
                {
                    //AdvertisingAds.StaticShow();
                }
                else
                    ErrorInternet.SetActive(true);

                // Camera.main.GetComponent<SnapshotMode>().Init = true;
                //Time.timeScale = 0f;
                var rigitbodys = FindObjectsOfType<Rigidbody2D>();
                foreach (var item in rigitbodys)
                {
                    //item.gravityScale = 0;
                    Destroy(item);
                }

            }
            else if (coll.gameObject.tag != "Playar")
            {
                Destroy(coll.gameObject);

                scoring++;
                OutScoringRealTime.text = scoring.ToString();
                //anim.Play();

            }


        }

        void Savelevel()
        {
            var namberLeve = GetNamberScene();
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
            OutScoring.text = "" + scoring;


        }
        void Update()
        {
            if ((Playr.transform.position - gameObject.transform.position).magnitude > 12f)
                Compass.SetActive(true);
            else Compass.SetActive(false);
            if (StartProgressCircle)
            {
                Circle.fillAmount += Mathf.Lerp(0f, 0.5f, Time.deltaTime);
                if (Circle.fillAmount >= precent)
                {
                    StartProgressCircle = false;
                    Circle.fillAmount = precent;
                }
            }
        }



    }
}
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace Tysseek {
    public class GameManager : MonoBehaviour
    {
        const float GRAVITY = 9.81f;
        public const string PLAYER = "Player";
        public const string ENEMY = "Enemy";

        static GameManager main;
        static public bool pause { get; private set; } = false;
        static public bool sound { get; private set; } = true;

        [SerializeField] GameSettings _settings;
        [SerializeField] Transform Player;
        [SerializeField] UnityEvent _playerWon;
        [SerializeField] UnityEvent _playerDied;
        Transform camera;
        UIManager _UIManager;

        private void Awake()
        {
            main = FindObjectOfType<GameManager>();
            _UIManager = FindObjectOfType<UIManager>();
        }
        void Start()
        {
            camera = Camera.main.transform;
            pause = false;
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                camera.RotateAround(Player.transform.position, Vector3.back, 5f);
                Physics2D.gravity = -camera.transform.up * GRAVITY;
            }
            if (Input.GetKey(KeyCode.D))
            {
                camera.RotateAround(Player.transform.position, Vector3.forward, 5f);
                Physics2D.gravity = -camera.transform.up * GRAVITY;
            }
        }
        public static void MakePause()
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        public static void SwitchMusic()
        {
            sound = !sound;
        }
        public static void OnHitting(Player player)
        {
            main._playerWon?.Invoke();
        }
        public static void OnHitting(Enemy enemy)
        {

        }
        public static void PlayerDied()
        {
            main._playerDied?.Invoke();
            Debug.Log("Player Died!!!");
            MakePause();
        }
        public static void EnemyDied()
        {
            Debug.Log("Enemy Died!!!");
        }

        static public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        public void OnDestroy()
        {
            main = null;
        }

        private void OnApplicationQuit()
        {
            Physics.gravity = Vector3.down * 9.81f;
        }
    }
}
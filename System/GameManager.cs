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
        [SerializeField] InputHub _input;
        [SerializeField] Transform Player;

        [SerializeField] UnityEvent _playerWon;
        [SerializeField] UnityEvent _playerDied;
        Transform _camera;
        UIManager _UIManager;

        private void Awake()
        {
            main = FindObjectOfType<GameManager>();
            _UIManager = FindObjectOfType<UIManager>();
        }
        void Start()
        {
            _camera = Camera.main.transform;
            pause = false;
            Time.timeScale = 1;
            Physics.gravity = Vector3.down * 9.81f;

            _input.left += RotateL;
            _input.right += RotateR;
        }
        
        void RotateL()
        {
            _camera.RotateAround(Player.transform.position, Vector3.back, 5f);
            Physics2D.gravity = -_camera.transform.up * GRAVITY;
        }
        void RotateR()
        {
            _camera.RotateAround(Player.transform.position, Vector3.forward, 5f);
            Physics2D.gravity = -_camera.transform.up * GRAVITY;
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
            MakePause();
            main._UIManager.HideHUD(false);
        }
        public static void OnHitting(Enemy enemy)
        {

        }
        public static void PlayerDied()
        {
            main._playerDied?.Invoke();
            MakePause();
            main._UIManager.HideHUD(false);
        }
        public static void EnemyDied()
        {
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
            
        }
    }
}
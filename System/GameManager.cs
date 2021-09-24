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
        public const string BLOCK = "Block";

        public const string STATE_MUSIC = "state_music";
        public const string STATE_SOUND = "state_Sound";

        static GameManager main;
        static public bool pause { get; private set; } = false;
        static public bool sound { get; set; } = true;
        [SerializeField] GameSettings _settings;
        [SerializeField] InputHub _input;
        [SerializeField] Transform _player;
        [SerializeField] CameraTracking _camera;
        [SerializeField] AudioHub _audioHub;
        [SerializeField] UIManager _UIManager;
        [SerializeField] SaveLoadSystem _SLSystem;
        [SerializeField] GameObject[] _toggleMusic;
        [SerializeField] GameObject[] _toggleSound;
        [SerializeField] GameObject _Ads;

        [SerializeField] UnityEvent _playerWon;
        [SerializeField] UnityEvent _playerDied;

        public static LevelData levelData { get; set; }
        public bool isPlayeMod { get; private set; }
        PlayerData playerData;
        public static PlayerData PlayerData { get; set; }
        public static byte countEnemy { get; set; }
        public static byte countEnemyExit { get; set; }


        private void Awake()
        {
            main = this;
            PlayerData = playerData = _SLSystem.Load();
        }
        void Start()
        {
            _input.left += RotateL;
            _input.right += RotateR;

            Input.simulateMouseWithTouches = true;
            _toggleMusic[0].SetActive(playerData.toggleMusic);
            _toggleMusic[1].SetActive(!playerData.toggleMusic);
            _audioHub.SwitchMusic(playerData.toggleMusic);

            _toggleSound[0].SetActive(playerData.toggleSund);
            _toggleSound[1].SetActive(!playerData.toggleSund);
            _audioHub.SwitchSound(playerData.toggleSund);
            GameManager.sound = playerData.toggleSund;

        }
        public void SubStart(LevelData levelData)
        {
            _player.transform.position = levelData.playerPos;

            if (levelData)
                StartCoroutine(Unpack(levelData));
            else
                Debug.LogWarning("not have LevelData");

            pause = false;
            Time.timeScale = 1;
            Physics2D.gravity = Vector3.down * 9.81f;

            _player.gameObject.SetActive(true);
            _camera.gameObject.SetActive(true);
            isPlayeMod = true;
            countEnemy = (byte)levelData.EnemyCollection.Length;
            countEnemyExit = 0;
            _UIManager.ResStart(_player);
        }

        IEnumerator Unpack(LevelData levelData)
        {
            levelData.Unpack();
            yield return new WaitForEndOfFrame();
        }
        public void Play()
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LoadScene(levelData));
        }
        public void Restart()
        {
            Physics2D.gravity = Vector3.down * 9.81f;
            _camera.transform.eulerAngles = Vector3.zero;
            var enemy = Enemy.enemies;
            for (int i = enemy.Count-1; i >= 0; i--)
            {
                enemy[i].transform.position = levelData.EnemyCollection[i].coordinates.position;
                enemy[i].gameObject.SetActive(true);
            }

            _player.transform.position = levelData.playerPos;
            _player.gameObject.SetActive(true);
            pause = false;
            Time.timeScale = 1;
            _UIManager.ResStart(_player);
            //_UIManager.HideHUD(true);
        }
        public void Home()
        {
            Physics2D.gravity = Vector3.down * 9.81f;
            Time.timeScale = 1;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            SceneManager.LoadScene(0);
        }
        public IEnumerator LoadScene(LevelData level)
        {
            DontDestroyOnLoad(gameObject);
            var asyncLoad = SceneManager.LoadSceneAsync(1);
            yield return new WaitUntil(() => asyncLoad.isDone);

            SubStart(level);
        }

        void RotateL()
        {
            _camera.transform.RotateAround(_player.transform.position, Vector3.back, 5f);
            Physics2D.gravity = -_camera.transform.up * GRAVITY;
        }
        void RotateR()
        {
            _camera.transform.RotateAround(_player.transform.position, Vector3.forward, 5f);
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
        
        public void SwitchMusic(bool turnOn)
        {
            _toggleMusic[0].SetActive(turnOn);
            _toggleMusic[1].SetActive(!turnOn);

            playerData.toggleMusic = turnOn;
            _audioHub.SwitchMusic(turnOn);
        }
        public void SwitchSound(bool turnOn)
        {
            _toggleSound[0].SetActive(turnOn);
            _toggleSound[1].SetActive(!turnOn);

            playerData.toggleSund = turnOn;
            _audioHub.SwitchSound(turnOn);
            GameManager.sound = turnOn;

        }
        public static void OnHitting(Player player)
        {
            var coefficient = 1f - ((1f / countEnemy) * countEnemyExit);
            Debug.LogFormat("coefficient = {0}", coefficient);

            main._playerWon?.Invoke();
            MakePause();
            main._UIManager.HideHUD(false);
            var starsCount = 0;
            if (coefficient > .6f)
                starsCount = 1;
            if (coefficient > .75f)
                starsCount = 2;
            if (coefficient > .9f)
                starsCount = 3;

            if (starsCount > 0)
                main.playerData.lastlevel += 1;
            levelData.stars = (byte)starsCount;
            main._UIManager.PlayerWon((byte)starsCount);
            
            Debug.Log("Hitt");
            main._SLSystem.playerData = main.playerData;
            main._SLSystem.Save();

        }
        public static void OnHitting(Enemy enemy)
        {
            countEnemyExit++;
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

       
        public void OnDestroy()
        {
            main = null;
        }

        
        public void OnApplicationQuit()
        {
            _SLSystem.playerData = playerData;
            _SLSystem.Save();
        }
    }
}
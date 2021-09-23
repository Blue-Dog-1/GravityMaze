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
        [SerializeField] UIManager _UIManager;

        [SerializeField] UnityEvent _playerWon;
        [SerializeField] UnityEvent _playerDied;

        public LevelData levelData { get; set; }
        private void Awake()
        {
            main = this;
        }
        void Start()
        {
            _input.left += RotateL;
            _input.right += RotateR;
        }
        public void SubStart(LevelData levelData)
        {
            this.levelData = levelData;
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
            _UIManager.SubStart();
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
            _UIManager.HideHUD(true);
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

       
        public void OnDestroy()
        {
            main = null;
        }

        private void OnApplicationQuit()
        {
            
        }
    }
}
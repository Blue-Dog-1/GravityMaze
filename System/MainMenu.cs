using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tysseek
{
    [AddComponentMenu("Project/MainMenu")]
    public class MainMenu : MonoBehaviour
    {
        public static MainMenu main
        {
            get; private set;
        }
        [SerializeField] GameManager _gameManager;
        [SerializeField] SaveLoadSystem _SLSystem;
        [SerializeField] Transform _area;
        [SerializeField] List<LevelPoint> _levelPoints;

        [SerializeField] float _velocityMoveCam = 1f;

        public PlayerData _playerData { get; set; }

        public void Awake()
        {
            main = this;
        }
        void Start()
        {
            var playerData = _playerData;
            if (playerData.lastlevel == 0) playerData.lastlevel = 1;
            playerData = _SLSystem.Load();
            LevelPoint.selectPoint = _levelPoints[playerData.lastlevel - 1];

            var point = _levelPoints[playerData.lastlevel - 1];
            point.level.isUnlocked = true;
            point.Instate();
        }
        public void Update()
        {
            if (LevelPoint.selectPoint)
                _area.position = LevelPoint.selectPoint.transform.position;
        }

        public void Play()
        {
            GameManager.levelData = LevelPoint.selectPoint.level;
        }

        
    }
}

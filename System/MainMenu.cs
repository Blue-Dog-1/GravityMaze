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
        [SerializeField] GameObject[] _toggleMusic;
        [SerializeField] GameObject[] _toggleSound;
        [SerializeField] GameObject _Ads;
        [SerializeField] AudioHub _audioHub;
        [SerializeField] Transform _area;
        [SerializeField] List<LevelPoint> _levelPoints;

        [SerializeField] float _velocityMoveCam = 1f;

        PlayerData _playerData;

        public void Awake()
        {
            main = this;
        }
        void Start()
        {
            var point = _levelPoints[_playerData.lastlevel];
            point.level.isUnlocked = true;
            point.Instate();
            _area.position = point.transform.position;
        }

        public void Play()
        {
            _gameManager.levelData = _levelPoints[_playerData.lastlevel].level;
        }

        
    }
}

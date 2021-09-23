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
            Input.simulateMouseWithTouches = true;
            _playerData = _SLSystem.Load();
            _toggleMusic[0].SetActive(_playerData.toggleMusic);
            _toggleMusic[1].SetActive(!_playerData.toggleMusic);
            _audioHub.SwitchMusic(_playerData.toggleMusic);

            _toggleSound[0].SetActive(_playerData.toggleSund);
            _toggleSound[1].SetActive(!_playerData.toggleSund);
            _audioHub.SwitchSound(_playerData.toggleSund);
            GameManager.sound = _playerData.toggleSund;

            var point = _levelPoints[_playerData.lastlevel];
            point.level.isUnlocked = true;
            point.Instate();
            _area.position = point.transform.position;
        }

        public void Play()
        {
            _gameManager.levelData = _levelPoints[_playerData.lastlevel].level;
        }

        


        public void SwitchMusic(bool turnOn)
        {
            _toggleMusic[0].SetActive(turnOn);
            _toggleMusic[1].SetActive(!turnOn);

            _playerData.toggleMusic = turnOn;
            _audioHub.SwitchMusic(turnOn);
        }
        public void SwitchSound(bool turnOn)
        {
            _toggleSound[0].SetActive(turnOn);
            _toggleSound[1].SetActive(!turnOn);

            _playerData.toggleSund = turnOn;
            _audioHub.SwitchSound(turnOn);
            GameManager.sound = turnOn;

        }


        public void Save()
        {
            var playerdata = _SLSystem.playerData;
            playerdata.lastlevel = 1;
            playerdata.toggleMusic = true;
            playerdata.toggleSund = true;

            _SLSystem.playerData = playerdata;
            _SLSystem.Save();
        }

        public void OnApplicationQuit()
        {
            _SLSystem.playerData = _playerData;
            _SLSystem.Save();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    [AddComponentMenu("Project/MainMenu")]
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] SaveLoadSystem _SLSystem;
        [SerializeField] GameObject[] _toggleMusic;
        [SerializeField] GameObject[] _toggleSound;
        [SerializeField] GameObject _Ads;
        [SerializeField] AudioHub _audioHub;

        [SerializeField] float _velocityMoveCam = 1f;

        PlayerData _playerData;

        float diraction;
        Transform _camera;

        void Start()
        {
            Input.simulateMouseWithTouches = true;
            _camera = Camera.main.transform;
            _playerData = _SLSystem.Load();
            _toggleMusic[0].SetActive(_playerData.toggleMusic);
            _toggleMusic[1].SetActive(!_playerData.toggleMusic);
            _audioHub.SwitchMusic(_playerData.toggleMusic);

            _toggleSound[0].SetActive(_playerData.toggleSund);
            _toggleSound[1].SetActive(!_playerData.toggleSund);
            _audioHub.SwitchSound(_playerData.toggleSund);
            GameManager.sound = _playerData.toggleSund;

        }
        Vector2 pressPosition;
        public void FixedUpdate()
        {
            if (Input.touchCount > 1)
            {
                diraction = Input.GetTouch(0).deltaPosition.y;
                _camera.position += (Vector3.forward * diraction * _velocityMoveCam);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    [AddComponentMenu("Project/Audio/AudioHub")]
    public class AudioHub : MonoBehaviour
    {

        [Header("UI Audio")]
        [SerializeField] AudioSource _audioUI;
        [SerializeField] AudioClip _clic;
        [SerializeField] AudioClip _OpenWindow;

        [Header("GamePlay Audio")]
        [SerializeField] AudioSource _audioGameplay;
        [SerializeField] AudioClip _soundVictory;
        [SerializeField] AudioClip _soundLoss;

        [SerializeField] AudioSource _ambient;
        void Start()
        {
        }

        public void SwitchMusic(bool value)
        {
            _ambient.volume = (value) ? 1 : 0;
        }
        public void SwitchSound(bool turnOn)
        {
            if (_audioUI)

                _audioUI.volume = (turnOn)? 1 : 0;

            if (_audioGameplay)
                _audioGameplay.volume = (turnOn) ? 1 : 0;
        }
        public void PlayClic()
        {
            _audioUI.clip = _clic;
            _audioUI.Play();
        }
        public void OnOpenWindow()
        {
            if (!GameManager.sound) return;
            _audioUI.clip = _OpenWindow;
            _audioUI.Play();
        }

        public void OnHitting()
        {
            if (!GameManager.sound) return;
            _audioGameplay.clip = _soundVictory;
            _audioGameplay.Play();
        }
        public void OnPlayerDied()
        {
            if (!GameManager.sound) return;
            _audioGameplay.clip = _soundLoss;
            _audioGameplay.Play();
        }
    }
}
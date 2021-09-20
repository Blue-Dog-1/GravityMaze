using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


namespace Tysseek
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] RectTransform _controlPanel;
        [Header("Windows")]
        [Header("End Session Window")]
        [SerializeField] RectTransform _WonWindow;
        [SerializeField] RectTransform _LostWindow;

        [Header("Pause Window")]
        [SerializeField] RectTransform _pauseWindow;
        [SerializeField] RectTransform _settingsWindow;

        [SerializeField] RectTransform _HUDElements;

        [Header("pause fields")]
        [SerializeField] Image _buttonPause;
        [SerializeField] Sprite _spritePause;
        [SerializeField] Sprite _spriteClose;

        [Header("sound fields")]
        [SerializeField] Image _buttonSound;
        [SerializeField] Sprite _musicOn;
        [SerializeField] Sprite _musicOff;

        void Start()
        {

        }

        void Update()
        {

        }
        public void EndSession()
        {
            _WonWindow.gameObject.SetActive(true);
        }
        public void Pouse()
        {
            GameManager.MakePause();
            _controlPanel.gameObject.SetActive(!GameManager.pause);
            _HUDElements.gameObject.SetActive(!GameManager.pause);

            _pauseWindow.gameObject.SetActive(GameManager.pause);
            if (GameManager.pause)
                _buttonPause.sprite = _spriteClose;
            else
                _buttonPause.sprite = _spritePause;

        }
        public void HideHUD(bool show)
        {
            _controlPanel.gameObject.SetActive(show);
            _HUDElements.gameObject.SetActive(show);
        }
        public void ExitToMainMenu()
        {
            Physics.gravity = Vector3.down * 9.81f;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        public void SwitchMusic()
        {
            GameManager.SwitchMusic();

            if (GameManager.sound)
                _buttonSound.sprite = _musicOff;
            else
                _buttonSound.sprite = _musicOn;
        }
        public void PlayerWon()
        {
            _WonWindow.gameObject.SetActive(true);
            _LostWindow.gameObject.SetActive(false);

        }
        public void PlayerLost()
        {
            _WonWindow.gameObject.SetActive(false);
            _LostWindow.gameObject.SetActive(true);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
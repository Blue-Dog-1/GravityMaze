using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Tysseek
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] RectTransform _controlPanel;
        [Header("Windows")]
        [SerializeField] RectTransform _endGameWindow;
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
            _endGameWindow.gameObject.SetActive(true);
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
            

        }
        public void PlayerLost()
        {

        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
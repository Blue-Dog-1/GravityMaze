using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace Tysseek
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameManager _gameManager;
        [SerializeField] RectTransform _controlPanel;
        [Header("Windows")]
        [Header("End Session Window")]
        [SerializeField] RectTransform _WonWindow;
        [SerializeField] Image[] _stars;
        [SerializeField] RectTransform _LostWindow;

        [Header("Pause Window")]
        [SerializeField] RectTransform _pauseWindow;
        [SerializeField] RectTransform _settingsWindow;

        [SerializeField] RectTransform _HUDElements;

        [Space]
        [SerializeField] Compass _compass;

        [Space]
        [SerializeField] UnityEvent _startGame;
        
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
        }
        public void HideHUD(bool show)
        {
            _controlPanel.gameObject.SetActive(show);
            _HUDElements.gameObject.SetActive(show);
        }
        public void ExitToMainMenu()
        {
            HideHUD(false);
            Physics.gravity = Vector3.down * 9.81f;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        public void OpenSetingsWindow(bool open)
        {
            _settingsWindow.gameObject.SetActive(open);

            if (_gameManager.isPlayeMod)
            {
                _pauseWindow.gameObject.SetActive(!open);
            }
        }
        public void ResStart(Transform player)
        {
            _startGame?.Invoke();
            HideHUD(true);

            _settingsWindow.gameObject.SetActive(false);
            _pauseWindow.gameObject.SetActive(false);
            _WonWindow.gameObject.SetActive(false);
            _LostWindow.gameObject.SetActive(false);
            _controlPanel.gameObject.SetActive(true);
            _HUDElements.gameObject.SetActive(true);
            var tagget = FindObjectOfType<Exit>();
            if (tagget)
                _compass.SetTarget(tagget.transform, player);
        }
        public void PlayerWon(byte countStars)
        {
            _WonWindow.gameObject.SetActive(true);
            _LostWindow.gameObject.SetActive(false);

            for (int i = 0; i < countStars; i++)
                _stars[i].color = Color.white;

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
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tysseek
{
    public class PauseMenu : MonoBehaviour
    {
        public LevelData levelData;
        [HideInInspector]
        public bool isPause;
        public GameObject PauseMenuUI;
        public Button ButtonNextLevelMenu0;
        public Button ButtonNextLevelMenu1;
        public GameObject languageSelection;

        void Start()
        {
            isPause = false;
            Time.timeScale = 1f;
            var namberLevel = Finish2D.GetNamberScene();
            

        }
        
        public void NexLevel()
        {
        }
        public void ChangeLanguage(bool flag)
        {
            languageSelection.SetActive(flag);
        }


    }
}
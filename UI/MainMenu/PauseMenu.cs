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
            if (levelData.isUnlocked.Length >= namberLevel)
            {
                if (!Application.CanStreamedLevelBeLoaded("level" + (namberLevel + 1)))
                {
                    ButtonNextLevelMenu0.interactable = false;
                    ButtonNextLevelMenu1.interactable = false;
                }
                else
                {
                    ButtonNextLevelMenu0.interactable = levelData.isUnlocked[namberLevel + 1];
                    ButtonNextLevelMenu1.interactable = levelData.isUnlocked[namberLevel + 1];
                }
            }

        }
        
        public void NexLevel()
        {
            SceneManager.LoadScene(levelData.nameLavel[Finish2D.GetNamberScene() + 1], LoadSceneMode.Single);
        }
        public void ChangeLanguage(bool flag)
        {
            languageSelection.SetActive(flag);
        }


    }
}
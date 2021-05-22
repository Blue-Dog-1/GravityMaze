using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (levelData.isUnlocked.Length >= namberLevel){
        if (!Application.CanStreamedLevelBeLoaded("level" + (namberLevel+1))){
            ButtonNextLevelMenu0.interactable = false;
            ButtonNextLevelMenu1.interactable = false;
        }
        else {
                ButtonNextLevelMenu0.interactable = levelData.isUnlocked[namberLevel+1];
                ButtonNextLevelMenu1.interactable = levelData.isUnlocked[namberLevel+1];
            }
        } 
        
    }
    
    public void Pause()
    {
        if (isPause){
            isPause = false;
            Time.timeScale = 1f;
            PauseMenuUI.SetActive(false);
            //Camera.main.GetComponent<SnapshotMode>().Init = false;
            
        }
        else {
            isPause = true;
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(true);
            //Camera.main.GetComponent<SnapshotMode>().Init = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        Physics.gravity = Vector3.down * 9.81f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Physics.gravity = Vector3.down * 9.81f;
        Application.Quit();
    }
    public void NexLevel()
    {
        SceneManager.LoadScene(levelData.nameLavel[Finish2D.GetNamberScene()+1], LoadSceneMode.Single);
    }
    public void ChangeLanguage(bool flag)
    {
        languageSelection.SetActive(flag);
    }
    

}

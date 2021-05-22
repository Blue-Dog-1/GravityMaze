using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    private Language language;
    [Header("LevelData")]
    public LevelData levelData;
    [Header("Dropdown")]
    public GameObject LanguageSelection;
    private TMPro.TMP_Dropdown dropdown;
    [Header("Languages")]
    public Language EN;
    public Language RU;
    public Language PL;
    public Language ES;
    public Language FR;
    public Language HI;
    public Language DE;

    public static Dictionary<string, string> text;
    void Awake()
    {   
        language = EN;
        if (levelData.isFirstStart)
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                language = EN;
                break;
            case SystemLanguage.Russian:
                levelData.language = SystemLanguage.Russian;
                language = RU;
                break;
            case SystemLanguage.Ukrainian: 
                levelData.language = SystemLanguage.Russian;
                language = RU;
                break;
            case SystemLanguage.Belarusian: 
                levelData.language = SystemLanguage.Russian;
                language = RU;
                break;
            case SystemLanguage.Estonian: 
                levelData.language = SystemLanguage.Estonian;
                language = ES;
                break;
        }
        else if (!levelData.isFirstStart)
        switch (levelData.language)
        {
            case SystemLanguage.English:
                levelData.language = SystemLanguage.English;
                language = EN;
                break;
            case SystemLanguage.Russian:
                levelData.language = SystemLanguage.Russian;
                language = RU;
                break;
        }
        getLang();
        

        levelData.isFirstStart = false;
    }
    void Start()
    {
        dropdown = LanguageSelection.GetComponent<TMPro.TMP_Dropdown>();
    }
    public void SetLanguage()
    {
        switch(dropdown.value)
        {
            case 0:
                levelData.language = SystemLanguage.English;
                language = EN;
                break;
            case 1:
                levelData.language = SystemLanguage.Russian;
                language = RU;
                break;
            case 2:
                break;
            case 3:
                break;
        }
        getLang();
    }

    void getLang()
    {
        text = new Dictionary<string, string>(language.list.Length);
        foreach (var item in language.list)
        {
            text[item.Key] = item.Velue;
        }
        Debug.Log(text["Hello"]);
    }
}

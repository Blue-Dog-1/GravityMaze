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
    }
    void Start()
    {
        dropdown = LanguageSelection.GetComponent<TMPro.TMP_Dropdown>();
    }
    public void SetLanguage()
    {
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LevelData", menuName = "PlayrData/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Settings")]
    public bool Vibrarion;
    public bool Music;
    public bool ads;
    public bool isFirstStart;
    public SystemLanguage language;

    [Header ("Level Data")]
    public string[] nameLavel;
    public bool[] isUnlocked;
    public Sprite[] image;
    public int[] scoring;
    public string[] objective;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

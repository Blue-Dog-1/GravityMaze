using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LevelData", menuName = "Projcet/LevelData")]
public class LevelData : ScriptableObject
{
    [Header ("Level Data")]
    [SerializeField] int _number;
    [SerializeField] bool _isUnlocked;

    public int number => _number;
    public bool isUnlocked => _isUnlocked;



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu (fileName = "Language", menuName = "PlayrData/Language")]
public class Language : ScriptableObject
{
    public List[] list;
}
[Serializable] 
public class List
{
    public string Key;
    [TextArea]
    public string Velue;
}
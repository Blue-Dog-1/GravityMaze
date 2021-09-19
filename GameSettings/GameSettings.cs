using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Project")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] bool _sound;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tysseek.Collections;
using System.Linq;

namespace Tysseek
{
    [CreateAssetMenu(fileName = "PrefabBundle", menuName = "Projcet/PrefabBundle")]
    public class PrefabBundle : ScriptableObject
    {
        [SerializeField] GameObject[] Prefab;

        public GameObject GetPrefab(string name)
        {
            var prefab = (from p in Prefab where p.name == name select p).ToArray();
            if (prefab.Length > 0)
                return prefab[0];

            return null;
        }
    }
}
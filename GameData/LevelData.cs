using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tysseek
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Projcet/LevelData"), SelectionBase]
    public class LevelData : ScriptableObject
    {
        [Header("Level Data")]
        [SerializeField] PrefabBundle _prefabBundle;
        [SerializeField] int _number = 1;
        [SerializeField] bool _isUnlocked = false;
        [SerializeField] byte _stars = 0;
        [SerializeField] Asset[] _assetCollection;

        public int number => _number;
        public bool isUnlocked { get => _isUnlocked; set => _isUnlocked = value; }
        public byte stars => _stars;

        public Asset[] assetCollection => _assetCollection;

        public void SetData(Asset[] assets)
        {
            _assetCollection = assets;
        }
        public void Unpack()
        {
            foreach (var data in _assetCollection)
            {
                var prefab = _prefabBundle.GetPrefab(data.name);
                if (!prefab) continue;
                var asset = Instantiate(prefab);
                asset.name = data.name;
                data.coordinates.Unpack(asset.transform);

            }
        }
    }
    [System.Serializable]
    public struct Asset
    {
        public string name;
        public Coordinates coordinates;
    }


}
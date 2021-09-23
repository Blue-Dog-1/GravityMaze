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
        [SerializeField] Vector3 _playerPosition;
        [SerializeField] PrefabBundle _prefabBundle;
        [SerializeField] int _number = 1;
        [SerializeField] bool _isUnlocked = false;
        [SerializeField] byte _stars = 0;
        [SerializeField] Asset[] _assetCollection;
        [SerializeField] Asset[] _enemyCollection;

        public int number => _number;
        public bool isUnlocked { get => _isUnlocked; set => _isUnlocked = value; }
        public byte stars => _stars;

        public Asset[] assetCollection => _assetCollection;
        public Asset[] EnemyCollection => _enemyCollection;
        public Vector3 playerPos { get => _playerPosition; set => _playerPosition = value; }

        public void SetData(Asset[] assets)
        {
            _assetCollection = assets;
        }
        public void SetDataEnemy(Asset[] assets)
        {
            _enemyCollection = assets;
        }
        public void Unpack()
        {
            UnpackEnemy();
            foreach (var data in _assetCollection)
            {
                var prefab = _prefabBundle.GetPrefab(data.name);
                if (!prefab) continue;
                var asset = Instantiate(prefab);
                asset.name = data.name;
                data.coordinates.Unpack(asset.transform);
            }
        }
        public void UnpackEnemy()
        {
            foreach (var data in _enemyCollection)
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
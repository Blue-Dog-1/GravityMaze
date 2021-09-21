using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tysseek
{
    [AddComponentMenu("Project/SaveLoadSystem")]
    public class SaveLoadSystem : MonoBehaviour
    {
        private string _path => Application.persistentDataPath + "/PlayerData.json";

        public PlayerData playerData { get; set; } = new PlayerData() { lastlevel = 1, toggleMusic = true, toggleSund = true };
        
        public void Save()
        {
            this.playerData = playerData;
            Debug.Log(_path);
            var json = JsonUtility.ToJson(playerData, true); // потом в folse незабудъ

            File.WriteAllText(_path, json);
        }
        public PlayerData Load()
        {
            if(!File.Exists(_path))
            {
                return playerData;
            }

            var json = File.ReadAllText(_path);

            playerData = JsonUtility.FromJson<PlayerData>(json);

            return playerData;
        }
    }

    [System.Serializable]
    public struct PlayerData
    {
        public int lastlevel;
        public bool toggleMusic;
        public bool toggleSund;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tysseek
{
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : Editor
    {
        LevelData data;
        private void OnEnable()
        {
            data = (LevelData)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Set data"))
            {
                Undo.RecordObject(data, "Add asset");
                if (Selection.gameObjects.Length == 0) return;
                var objects = Selection.gameObjects;
                Asset[] assets = new Asset[objects.Length];

                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects[i].transform == null) continue;
                    
                    var name = objects[i].name;
                    assets[i].name = name;

                    assets[i].coordinates.Convert(objects[i].transform);
                }

                data.SetData(assets);
                EditorUtility.SetDirty(data);
            }
            if (GUILayout.Button("Add data"))
            {
                Undo.RecordObject(data, "Add asset");
                if (Selection.gameObjects.Length == 0) return;
                var objects = Selection.gameObjects;
                Asset[] assets = new Asset[data.assetCollection.Length + objects.Length];
                for (int i = 0; i < data.assetCollection.Length; i++)
                {
                    assets[i] = data.assetCollection[i];
                }

                for (int i = data.assetCollection.Length; i < objects.Length; i++)
                {
                    if (objects[i].transform == null) continue;

                    var name = objects[i].name;
                    assets[i].name = name;

                    assets[i].coordinates.Convert(objects[i].transform);
                }

                data.SetData(assets);
                EditorUtility.SetDirty(data);
            }


            if (GUILayout.Button("Unpack"))
            {
                Undo.RegisterSceneUndo("Unpuc");
                data.Unpack();
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }

        }
    }
}

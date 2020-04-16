using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEditor;

namespace HackManC1
{
    public class JsonLevelExportWindow : EditorWindow
    {
        private string levelName;
        
        public static int[,] grid = new int[,]
        {
            {1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1},
            {1 , 0 , 1 , 0 , 0 , 0 , 0 , 3 , 0 , 1},
            {1 , 0 , 2 , 0 , 1 , 0 , 1 , 0 , 1 , 1},
            {1 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1},
            {1 , 0 , 1 , 0 , 1 , 0 , 1 , 1 , 0 , 1},
            {1 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 1},
            {1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1}
        };
        
        [MenuItem("Tools/HackMan/JSON Level Exportor")]
        private static void ShowWindow()
        {
            var window = GetWindow<JsonLevelExportWindow>();
            window.Show();
        }

        // Is kind of like Update...
        private void OnGUI()
        {
            GUILayout.Label("JSON Exporter");
            GUILayout.Label("Please name your level to export");

            levelName = EditorGUILayout.TextField(levelName);
            
            if(!GUILayout.Button("Export")) return;
            
            LevelData levelData = new LevelData(){Name = levelName, Grid = grid, GridOneDimensional = new []{1, 2, 3, 4}};

            // var levelDataAsJSON = AppDataSystem.Save(levelData, "level1");
            AppDataSystem.Save(levelData, levelName);
            
            // // var levelDataAsJSON = JsonUtility.ToJson(levelData);
            // var levelDataAsJSON = JsonConvert.SerializeObject(levelData);
            // // File.WriteAllText($"{Application.dataPath}/HackMan/AppData/Levels/{levelName}.json", levelDataAsJSON);
            // File.WriteAllText($"{Application.streamingAssetsPath}/Levels/{levelName}.json", levelDataAsJSON);
            // Debug.Log(levelDataAsJSON);
        }
    }
}

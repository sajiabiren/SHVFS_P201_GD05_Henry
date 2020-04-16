using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace HackManC1
{
    public class AppDataSystem
    {
        // Save the object to a file, safely (create directories if they're not already there, etc.)'
        public static void Save<T>(T data, string fileName)
        {
            if (!File.Exists($"{Application.streamingAssetsPath}/{fileName}.json"))
            {
                var levelDataAsJSON = JsonConvert.SerializeObject(data);
                File.WriteAllText($"{Application.streamingAssetsPath}/{fileName}.json", levelDataAsJSON);
                
                Debug.Log(levelDataAsJSON);
            }
        }

        public static T Load<T>(string fileName)
        {
            var dataText = File.ReadAllText($"{Application.streamingAssetsPath}/{fileName}.json");
            Debug.Log(dataText);
            
            return JsonConvert.DeserializeObject<T>(dataText);
        }
    }
}
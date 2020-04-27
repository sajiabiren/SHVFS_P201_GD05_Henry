using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace HackManC1
{
    public class RecordDataManager : Singleton<RecordDataManager>
    {
        private static RecordData record = new RecordData();
        public static int[] rank = {0, 0, 0, 0, 0};
        
        private bool firstTime = true;
    
        private void Awake()
        {
            if (!File.Exists($"{Application.dataPath}/Appdata/Record.json"))
            {
                record.Record = rank;
                StoreData();
            }

            var rankOfRecord = File.ReadAllText($"{Application.dataPath}/Appdata/Record.json");
            rank = JsonConvert.DeserializeObject<RecordData>(rankOfRecord).Record;
        }
        
        public void UpdateData()
        {
            // Update the rank of record
            if (!rank.Contains((int) ScoreComponent.Instance.score))
            {
                if (rank[4] < (int)ScoreComponent.Instance.score)
                {
                    rank[4] = (int)ScoreComponent.Instance.score;
                    for (int j = 4; j > 0; j--)
                    {
                        if (rank[j] > rank[j - 1])
                        {
                            var k = rank[j - 1];
                            rank[j - 1] = rank[j];
                            rank[j] = k;
                        }
                    }
                }
            }
            record.Record = rank;
            
            StoreData();
        }

        public void StoreData()
        {
            var recordDataAsJSON = JsonConvert.SerializeObject(record);
            File.WriteAllText($"{Application.dataPath}/Appdata/Record.json", recordDataAsJSON);
        }
    }
}


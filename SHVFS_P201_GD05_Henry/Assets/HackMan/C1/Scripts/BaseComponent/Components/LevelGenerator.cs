using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace HackManC1
{
    public class LevelGenerator : MonoBehaviour
    {
        public string levelName;
        public BaseGridObject[] BaseGridObjectPrefabs;

        public static int[,] Grid = new int[,]
        {
//            {1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1},
//            {1 , 0 , 1 , 0 , 0 , 0 , 0 , 3 , 0 , 1},
//            {1 , 0 , 2 , 0 , 1 , 0 , 1 , 0 , 1 , 1},
//            {1 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1},
//            {1 , 0 , 1 , 0 , 1 , 0 , 1 , 1 , 0 , 1},
//            {1 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 1},
//            {1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1}
        };

        private void Awake()
        {
            // var levelDataText = Level.text;
            // Grid = JsonConvert.DeserializeObject<LevelData>(levelDataText).Grid;
            
            Grid = AppDataSystem.Load<LevelData>(levelName).Grid;
            
            var gridSizeX = Grid.GetLength(1);
            var gridSizeY = Grid.GetLength(0);
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    var objectType = Grid[y, x];
                    var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                    var gridObjectClone = Instantiate(gridObjectPrefab);

                    // Set the grid position
                    gridObjectClone.GridPosition = new IntVector2(x, -y);
                    // Move the gameobject to its grid position
                    gridObjectClone.transform.position = gridObjectClone.GridPosition.AsVector3();
                    //gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y);
                }
            }
        }
    }
}


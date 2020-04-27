using System.Collections;
using System.Collections.Generic;
using HackManC1;
using UnityEngine;

namespace HackManC1
{
    public class GameManager : Singleton<GameManager>
    {
        public static GameOverUI gameOverUI;
        
        private void Awake()
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}


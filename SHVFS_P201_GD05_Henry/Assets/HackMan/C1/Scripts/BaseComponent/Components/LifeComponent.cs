using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackManC1
{
    public class LifeComponent : Singleton<LifeComponent>
    {
        public int life = 3;
    
        private void Update()
        {
            if (life == 0)
            {
                Debug.Log("Game Over!");
                
                GameOverSystem.Instance.Init();
                Evently.Instance.Publish(new GameOverEvent(GameManager.gameOverUI));
            }
        }
    }
}


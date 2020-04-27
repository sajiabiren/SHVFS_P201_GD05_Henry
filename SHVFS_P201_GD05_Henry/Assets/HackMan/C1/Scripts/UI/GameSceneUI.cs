using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HackManC1
{
    public class GameSceneUI : Singleton<GameSceneUI>
    {
        public Text Life;
        public Text Score;

//        private void Awake()
//        {
//            DontDestroyOnLoad(this);
//        }

        private void Update()
        {
            Life.text = $"Life: {LifeComponent.Instance.life}";
            Score.text = $"Score: {ScoreComponent.Instance.score}";
        }
    
        public void Quit()
        {
            Application.Quit();
        }
    
        public void Restart()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}


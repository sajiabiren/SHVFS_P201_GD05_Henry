using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HackManC1
{
    public class GameOverUI : MonoBehaviour
    {
        public Text score;
        public GameObject recordBoard;

        private void Awake()
        {
            Invoke("SetActiveFalse", 0.01f);
        }

        private void OnEnable()
        {
            score.text = $"Score: {ScoreComponent.Instance.score}";
        }

        public void Quit()
        {
            Application.Quit();
        }
        
        public void Restart()
        {
            LifeComponent.Instance.life = 3;
            ScoreComponent.Instance.score = 0;
            SceneManager.LoadScene("GameScene");
        }
        
        public void Record()
        {
            recordBoard.gameObject.SetActive(true);
        }

        private void SetActiveFalse()
        {
            Debug.Log(1);
            gameObject.SetActive(false);
        }
    }
}


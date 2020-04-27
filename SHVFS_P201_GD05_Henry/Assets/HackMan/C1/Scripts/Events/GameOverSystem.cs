using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackManC1
{
    public class GameOverSystem : Singleton<GameOverSystem>
    {
        public void Init()
        {
        }
        
        // I need to subscribe to some message and do something, when I'm collecting...
        private void OnEnable()
        {
            Evently.Instance.Subscribe<GameOverEvent>(OnGameOverEvent);
        }
        
        private void OnDisable()
        {
            Evently.Instance.Unsubscribe<GameOverEvent>(OnGameOverEvent);
        }
        
        private void OnGameOverEvent(GameOverEvent evt)
        {
            RecordDataManager.Instance.UpdateData();
            evt.GOUI.gameObject.SetActive(true);
        }
    }
}
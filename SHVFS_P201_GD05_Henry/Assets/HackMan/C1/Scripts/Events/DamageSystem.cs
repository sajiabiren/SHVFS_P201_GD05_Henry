using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackManC1
{
    public class DamageSystem : Singleton<DamageSystem>
    {
        public void Init(){}
        
        // I need to subscribe to some message and do something, when I'm collecting...
        private void OnEnable()
        {
            Evently.Instance.Subscribe<DamageEvent>(OnDamageEvent);
        }
        
        private void OnDisable()
        {
            Evently.Instance.Unsubscribe<DamageEvent>(OnDamageEvent);
        }
        
        private void OnDamageEvent(DamageEvent evt)
        {
            LifeComponent.Instance.life -= 1;
            Destroy(evt.Damageble.gameObject);
            if (LifeComponent.Instance.life != 0)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
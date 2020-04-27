using UnityEngine;

namespace HackManC1
{
    public class DamagerComponent : MonoBehaviour
    {
        // I need to public some message, that I damage something...
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<DamagebleComponent>())
            {
                DamageSystem.Instance.Init();
                Evently.Instance.Publish(new DamageEvent(other.GetComponent<DamagebleComponent>()));
            }
        }
    }
}
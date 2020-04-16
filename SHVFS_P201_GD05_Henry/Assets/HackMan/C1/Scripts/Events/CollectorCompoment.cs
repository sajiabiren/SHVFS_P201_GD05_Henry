using UnityEngine;

namespace HackManC1
{
    public class CollectorCompoment : MonoBehaviour
    {
        // I need to public some message, that I collected something...
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<CollectableComponent>())
            {
                Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
            }
        }
    }
}
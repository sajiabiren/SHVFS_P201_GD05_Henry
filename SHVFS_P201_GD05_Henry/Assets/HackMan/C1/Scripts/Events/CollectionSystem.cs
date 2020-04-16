using UnityEngine;

namespace HackManC1
{
    public class CollectionSystem : MonoBehaviour
    {
        // I need to subscribe to some message and do something, when I'm collecting...
        private void OnEnable()
        {
            Evently.Instance.Subscribe<CollectionEvent>(OnCollectionEvent);
        }
        
        private void OnDisable()
        {
            Evently.Instance.Unsubscribe<CollectionEvent>(OnCollectionEvent);
        }
        
        private void OnCollectionEvent(CollectionEvent evt)
        {
            Destroy(evt.Collectable.gameObject);
        }
    }
}
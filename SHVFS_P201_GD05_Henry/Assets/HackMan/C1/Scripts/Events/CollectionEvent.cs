using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class CollectionEvent
    {
        public CollectableComponent Collectable;

        public CollectionEvent(CollectableComponent collectable)
        {
            Collectable = collectable;
        }
    }
}
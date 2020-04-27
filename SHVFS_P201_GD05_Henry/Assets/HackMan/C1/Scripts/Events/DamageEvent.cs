using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class DamageEvent
    {
        public DamagebleComponent Damageble;
    
        public DamageEvent(DamagebleComponent damageble)
        {
            Damageble = damageble;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class GameOverEvent
    {
        public GameOverUI GOUI;
    
        public GameOverEvent(GameOverUI gOUI)
        {
            GOUI = gOUI;
        }
    }
}


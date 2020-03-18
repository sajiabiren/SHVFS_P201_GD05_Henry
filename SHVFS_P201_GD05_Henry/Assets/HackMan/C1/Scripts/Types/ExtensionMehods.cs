using UnityEngine;

namespace HackManC1
{
    public static class ExtensionMehods
    {
        public static Vector3 AsVector3(this IntVector2 intVector2)
        {
            return new Vector3(intVector2.x, intVector2.y);
        }
    }
}


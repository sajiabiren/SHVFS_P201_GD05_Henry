﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public struct IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        // Operator Function

        public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.x + v2.x, v1.y + v2.y);
        }

        // a + b == ??
        // a - b == a + (-b)

        public static IntVector2 operator -(IntVector2 v)
        {
            return new IntVector2(-v.x, -v.y);
        }

        public static bool operator ==(IntVector2 v1, IntVector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator !=(IntVector2 v1, IntVector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }
    }
}


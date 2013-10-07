using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JSONFarseer
{
    static class Extensions
    {
        public static Vector2 ToVector(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}

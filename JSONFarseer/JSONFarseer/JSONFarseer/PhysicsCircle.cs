using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JSONFarseer
{
    struct PhysicsCircle
    {
        public Vector2 Position;
        public float Radius;

        public PhysicsCircle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }
    }
}

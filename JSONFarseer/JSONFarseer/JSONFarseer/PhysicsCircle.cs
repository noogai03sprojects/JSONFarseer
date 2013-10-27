using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JSONFarseer
{
    public class PhysicsCircle : IDraggable
    {
        public Vector2 Position;
        public float Radius;

        public PhysicsCircle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }
    }
}

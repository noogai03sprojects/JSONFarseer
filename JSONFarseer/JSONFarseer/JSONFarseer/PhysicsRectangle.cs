using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JSONFarseer
{
    struct PhysicsRectangle
    {
        public Vector2 Position;
        public float Width;
        public float Height;
        public float Rotation;

        public PhysicsRectangle(Vector2 position, float width, float height, float rotation)
        {
            Position = position;
            Width = width;
            Height = height;
            Rotation = rotation;
        }
    }
}

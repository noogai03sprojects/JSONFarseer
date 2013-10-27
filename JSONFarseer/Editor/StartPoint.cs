using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JSONFarseer;

namespace Editor
{
    class StartPoint : IDraggable
    {
        public Vector2 Position;
        public const float radius = 30;

        static Color StartPointColor = new Color(164, 252, 148, 100);

        public StartPoint(Vector2 position)
        {
            Position = position;
        }

        public void Draw(PrimitiveBatch primBatch)
        {
            primBatch.DrawFilledCircle(Position, radius, StartPointColor);
            primBatch.DrawFilledCircle(Position, 5, Color.Green);
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public bool ContainsPoint(Vector2 point)
        {
            return (Position - point).LengthSquared() < (radius * radius);
        }
    }
}

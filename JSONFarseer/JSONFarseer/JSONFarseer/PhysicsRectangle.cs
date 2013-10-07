using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.De
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace JSONFarseer
{
    [DataContract]
    public class PhysicsRectangle
    {
        //[JsonIgnore]
        public Vector2 Position { get { return position; } set { position = value; } }
        [DataMember]
        private Vector2 position;

        public float Width { get { return width; } set { width = Math.Abs(value); } }
        [DataMember]
        private float width;

        public float Height { get { return height; } set { height = Math.Abs(value); } }
        [DataMember]
        private float height;

        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }
        [DataMember]
        private float rotation;

        public Vector2 Size { get { return new Vector2(Width, Height); } }

        public Vector2 HalfSize
        {
            get
            {
                return Size / 2;
            }
        }

        public Vector2 TopLeft
        {
            get
            {
                if (Rotation == 0)
                    return Position - HalfSize;
                else
                    throw new Exception("rect is rotated, cba to do maths");                
            }
            set
            {
                if (Rotation == 0)
                {
                    Vector2 tempBottomRight = BottomRight;
                    Width = tempBottomRight.X - value.X;
                    Height = tempBottomRight.Y - value.Y;
                    Position = tempBottomRight - HalfSize;
                }
                else
                    throw new Exception("rect is rotated, cba to do maths");
            }
        }

        public Vector2 BottomRight
        {
            get
            {
                if (Rotation == 0)
                    return Position + HalfSize;
                else
                    throw new Exception("rect is rotated, cba to do maths");                  
            }
            set
            {
                if (Rotation == 0)
                {
                    Vector2 tempTopLeft = TopLeft;
                    Width = value.X - tempTopLeft.X;
                    Height = value.Y - tempTopLeft.Y;
                    Position = tempTopLeft + HalfSize;
                }
                else
                    throw new Exception("rect is rotated, cba to do maths");                  
            }
        }

        public PhysicsRectangle()
        {

        }

        public PhysicsRectangle(Vector2 position, float width, float height, float rotation)
        {
            Position = position;
            Width = width;
            Height = height;
            Rotation = rotation;
        }

        public PhysicsRectangle(Vector2 topLeft, Vector2 bottomRight, float rotation)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
            //Height = bottomRight.Y - topLeft.Y;
            Rotation = rotation;
        }

        public static PhysicsRectangle Empty = new PhysicsRectangle(Vector2.Zero, 0, 0, 0);
    }
}

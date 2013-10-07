using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JSONFarseer
{
    static class Camera
    {
        static Vector2 Position = Vector2.Zero;
        static Vector2 Target = Vector2.Zero;
        static float MoveSpeed = 0.1f;

        static Vector2 Origin;

        public static float ZoomAmount { get; private set; }
        static float ZoomTarget = 1;
        static float ZoomSpeed = 0.1f;

        static Matrix _Transform;

        public static Matrix MouseTransform;

        //Viewport viewport;

        public static Matrix Transform
        {
            get { return _Transform; }
        }

        public static Vector2 Offset
        {
            get { return Position; }
        }

        public static void Initialize(Viewport _viewport)
        {
            Origin = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
            ZoomAmount = 1;

            //viewport = _viewport;

            _Transform = Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateScale(ZoomAmount, ZoomAmount, 0) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));


        }

        public static void Move(Vector2 delta)
        {
            Position += delta;
        }
        public static void Zoom(float amount)
        {
            ZoomAmount += amount;
        }

        public static void GoTo(Vector2 target, float speed)
        {
            Target = target;
            MoveSpeed = speed;
        }
        public static void GoTo(Vector2 target)
        {
            Target = target;
        }

        public static void ZoomTo(float target, float speed)
        {
            ZoomTarget = target;
            ZoomSpeed = speed;
        }

        public static void Update()
        {
            MoveCamera();
            _Transform = Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateScale(ZoomAmount, ZoomAmount, 0) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
            MouseTransform = Matrix.CreateTranslation(new Vector3(Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateScale(ZoomAmount, ZoomAmount, 0) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        private static void MoveCamera()
        {
            Position.X = Position.X + Origin.X;
            Position.Y = Position.Y + Origin.Y;

            //Position = Vector2.Lerp(Position, Target, MoveSpeed);

            Position.X = Position.X - Origin.X;
            Position.Y = Position.Y - Origin.Y;

            Position.Y = (float)Math.Round(Position.Y);
            Position.X = (float)Math.Round(Position.X);

            //ZoomAmount = MathHelper.Lerp(ZoomAmount, ZoomTarget, ZoomSpeed);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;

namespace JSONFarseer
{
    static class PhysicsCore
    {
        public static bool IsIntitialized = false;

        private static World world;
        public static World World { get { return world; } set { world = value; } }

        public const float MetreInPixels = 64f;
        public const float PPM = MetreInPixels;
        public const float MIP = PPM;

        public const float PixelInMetres = 1 / MetreInPixels;
        public const float MPP = PixelInMetres;
        public const float PIM = MPP;

        public static float ToPixels(float Metres)
        {
            return Metres * MetreInPixels;
        }
        public static float ToMetres(float Pixels)
        {
            return Pixels * PixelInMetres;
        }
        public static Vector2 ToPixels(Vector2 Metres)
        {
            return Metres * MetreInPixels;
        }

        public static Vector2 ToMetres(Vector2 Pixels)
        {
            return Pixels * PixelInMetres;
        }

        /// <summary>
        /// Sets up Farseer for physics. Must be called before most stuff.
        /// </summary>
        /// <param name="gravity">The gravity to use for the world.</param>
        public static void Initialize(Vector2 gravity)
        {
            World = new World(gravity);
            IsIntitialized = true;
        }

        public static void CreatePhysicsShapes(PhysicsRectangle[] rectangles, PhysicsCircle[] circles)
        {
            foreach (PhysicsRectangle rectangle in rectangles)
            {
                Body body = BodyFactory.CreateRectangle(world, ToMetres(rectangle.Width), ToMetres(rectangle.Height), 1, ToMetres(rectangle.Position));
                body.Rotation = rectangle.Rotation;
            }

            foreach (PhysicsCircle circle in circles)
            {
                Body body = BodyFactory.CreateCircle(World, circle.Radius, 1, circle.Position);
            }
        }
    }
}

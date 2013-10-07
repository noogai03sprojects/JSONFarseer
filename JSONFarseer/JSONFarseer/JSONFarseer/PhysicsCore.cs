using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;
using FarseerPhysics.DebugViews;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;

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

            debug = new DebugViewXNA(World);

            IsIntitialized = true;
        }

        public static void CreateStaticPhysicsShapes(List<PhysicsRectangle> rectangles, List<PhysicsCircle> circles)
        {
            foreach (PhysicsRectangle rectangle in rectangles)
            {
                Body body = BodyFactory.CreateRectangle(world, ToMetres(rectangle.Width), ToMetres(rectangle.Height), 1, ToMetres(rectangle.Position));
                body.Rotation = rectangle.Rotation;
                Console.WriteLine(rectangle.Rotation);
            }

            foreach (PhysicsCircle circle in circles)
            {
                Body body = BodyFactory.CreateCircle(World, circle.Radius, 1, circle.Position);
            }
        }

        public static Body CreateFromPhysicsData(Vector2 position, List<PhysicsRectangle> rectangles, List<PhysicsCircle> circles)
        {
            throw new NotImplementedException();
        }

        static DebugViewXNA debug;
        static Matrix view;
        static Matrix projection;

        public static void LoadDebugContent(GraphicsDevice device, ContentManager content)
        {
            debug.LoadContent(device, content);
        }

        public static void Update(GameTime gameTime)
        {
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public static void DrawDebugData(GraphicsDevice device, PrimitiveBatch primBatch)
        {
            projection = Matrix.CreateOrthographicOffCenter(0f, device.Viewport.Width / MetreInPixels,
                                                         device.Viewport.Height / MetreInPixels, 0f, 0f,
                                                         1f);

            Matrix view = Matrix.CreateTranslation(new Vector3((ToMetres(-Camera.Offset)), 0f))
                * Matrix.CreateTranslation(new Vector3(ToMetres(-GameRoot.ScreenCentre), 0f))
                * Matrix.CreateScale(Camera.ZoomAmount, Camera.ZoomAmount, 0)
                * Matrix.CreateTranslation(new Vector3(ToMetres(GameRoot.ScreenCentre), 0f));
            
            debug.RenderDebugData(ref projection, ref view);        
        }
    }
}

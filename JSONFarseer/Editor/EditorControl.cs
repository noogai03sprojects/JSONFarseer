using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Editor
{
    class EditorControl : GraphicsDeviceControl
    {
        Stopwatch timer;

        SpriteBatch spriteBatch;
        ContentManager content;

        Texture2D test;

        PrimitiveBatch primitiveBatch;

        float delta;

        Vector2 ScreenCentre;

        protected override void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(GraphicsDevice);

            content = new ContentManager(Services);
            content.RootDirectory = "Content";

            LoadContent(content);

            ScreenCentre = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height) / 2;
        }

        public void LoadContent(ContentManager content)
        {
            test = content.Load<Texture2D>("1v1");
            timer = Stopwatch.StartNew();
        }

        public void LoadLevel(string path)
        {
            //Console.WriteLine(path);

            StreamReader reader = new StreamReader(path);

            string data;

            using (reader)
            {
                data = reader.ReadToEnd();
            }
            Console.Write(data);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            delta = (float)timer.Elapsed.TotalMilliseconds;
            timer.Restart();

            

            spriteBatch.Begin();

            spriteBatch.Draw(test, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            primitiveBatch.DrawRectangle(true, ScreenCentre, new Vector2(100, 100), 1f, Color.Red);
        }
    }
}

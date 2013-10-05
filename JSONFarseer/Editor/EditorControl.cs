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

        float angle = 0;

        protected override void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(GraphicsDevice);
            Art.GraphicsDevice = GraphicsDevice;

            content = new ContentManager(Services);
            content.RootDirectory = "Content";

            LoadContent(content);

            ScreenCentre = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height) / 2;
        }        

        public void LoadContent(ContentManager content)
        {
            //FileStream stream = new FileStream("C:\\Users\\Noogai03\\Pictures\\ash.jpg", FileMode.Open);
            //test = Texture2D.FromStream(GraphicsDevice, stream);
            //test = content.Load<Texture2D>(
            //test = Art.LoadTextureStream("C:\\Users\\Noogai03\\Pictures\\ash.jpg");
            test = content.Load<Texture2D>("1v1");
            timer = Stopwatch.StartNew();
        }

        public void LoadLevel(string path)
        {
            LevelManager.LoadLevel(path);

            
        }

        private void Update(float delta)
        {
            LevelManager.Update(delta);

            angle += 0.5f * delta;
        }

        protected override void Draw()
        {
            delta = (float)timer.Elapsed.TotalSeconds;
            timer.Restart();

            Update(delta);

            GraphicsDevice.Clear(Color.CornflowerBlue);


            LevelManager.Draw(primitiveBatch, spriteBatch);
            

            spriteBatch.Begin();

            spriteBatch.Draw(test, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            primitiveBatch.DrawRectangle(false, ScreenCentre, new Vector2(100, 100), angle, Color.Red);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using System.Diagnostics;

namespace Editor
{
    class EditorControl : GraphicsDeviceControl
    {
        Stopwatch timer;

        SpriteBatch spriteBatch;
        ContentManager content;

        Texture2D test;

        PrimitiveBatch primitiveBatch;

        protected override void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(GraphicsDevice);

            content = new ContentManager(Services);
            content.RootDirectory = "Content";

            LoadContent(content);
        }

        public void LoadContent(ContentManager content)
        {
            test = content.Load<Texture2D>("1v1");
            timer = Stopwatch.StartNew();
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //float delta = (float)timer.Elapsed.TotalMilliseconds;
            //timer.Restart();

            

            spriteBatch.Begin();

            spriteBatch.Draw(test, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            

            primitiveBatch.Begin(PrimitiveType.LineList);
            primitiveBatch.AddVertex(new Vector2(0, 0), Color.Black);
            primitiveBatch.AddVertex(new Vector2(300, 300), Color.Purple);
            primitiveBatch.AddVertex(new Vector2(300, 300), Color.Purple);
            primitiveBatch.AddVertex(new Vector2(0, 300), Color.Purple);            

            primitiveBatch.End();

            primitiveBatch.Begin(PrimitiveType.TriangleList);

            primitiveBatch.DrawCircle(new Vector2(100, 100), 64, Color.Red);
            primitiveBatch.AddVertex(new Vector2(0, 0), Color.Red);
            primitiveBatch.AddVertex(new Vector2(300, 300), Color.Blue);
            primitiveBatch.AddVertex(new Vector2(0, 300), Color.Purple);   

            primitiveBatch.End();
        }
    }
}

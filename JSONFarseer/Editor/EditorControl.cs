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
        protected override void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            content = new ContentManager(Services);
            content.RootDirectory = "Content";
        }

        private void LoadContent(ContentManager content)
        {
            test = content.Load<Texture2D>("1v1");
            timer = Stopwatch.StartNew();
        }

        protected override void Draw()
        {
            float delta = (float)timer.Elapsed.TotalMilliseconds;
            timer.Restart();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(test, new Vector2(10, 10), Color.White);

            spriteBatch.End();
        }
    }
}

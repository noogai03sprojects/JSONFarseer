using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Diagnostics;

namespace Editor
{
    class TestXNAControl : GraphicsDeviceControl
    {
        ContentManager Content;
        SpriteBatch spriteBatch;

        Texture2D image;
        Vector2 pos = new Vector2(10, 10);

        Stopwatch timer;

        Rectangle rectangle = new Rectangle(40, 40, 400, 40);

        Texture2D pixel;

        protected override void Initialize()
        {
            Content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Application.Idle += delegate { Invalidate(); };

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            Color[] data = new Color[1];
            data[0] = Color.White;
            pixel.SetData<Color>(data);

            image = Content.Load<Texture2D>("1v1");

            timer = Stopwatch.StartNew();
        }

        //protected override 
        private void Update(float delta)
        {
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                pos += new Vector2(1, 1) * delta;
            }
        }

        public void MouseClick(Vector2 pos)
        {
            this.pos = pos;
        }

        protected override void Draw()
        {
            float delta = (float)timer.Elapsed.TotalMilliseconds;
            timer.Restart();

            Update(delta);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(pixel, rectangle, Color.Red);

            spriteBatch.Draw(image, pos, Color.White);

            spriteBatch.End();
            //throw new NotImplementedException();
        }
    }
}

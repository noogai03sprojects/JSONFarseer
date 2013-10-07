using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Newtonsoft.Json;

namespace JSONFarseer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameRoot : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GameRoot Instance;

        Texture2D texture;

        //Camera2D camera;

        public static Vector2 ScreenCentre;

        public GameRoot()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here            
            PhysicsCore.Initialize(new Vector2(0, 9.82f));
            Camera.Initialize(GraphicsDevice.Viewport);

            ScreenCentre = GraphicsDevice.Viewport.Bounds.Center.ToVector();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("1v1");

            LevelManager.LoadLevel("data\\testLevel.json");

            PhysicsCore.LoadDebugContent(GraphicsDevice, Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            Camera.Update();

            float MoveSpeed = 5;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {
                Camera.Move(new Vector2(MoveSpeed, 0));
            }
            if (state.IsKeyDown(Keys.Left))
            {
                Camera.Move(new Vector2(-MoveSpeed, 0));
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Camera.Move(new Vector2(0, -MoveSpeed));
            }
            if (state.IsKeyDown(Keys.Down))
            {
                Camera.Move(new Vector2(0, MoveSpeed));
            }
            if (state.IsKeyDown(Keys.Add))
            {
                Camera.Zoom(0.01f);
                Console.WriteLine(Camera.ZoomAmount);
            }
            if (state.IsKeyDown(Keys.Subtract))
            {
                Camera.Zoom(-0.01f);
                Console.WriteLine(Camera.ZoomAmount);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.Transform);

            spriteBatch.Draw(texture, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            PhysicsCore.DrawDebugData(GraphicsDevice);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

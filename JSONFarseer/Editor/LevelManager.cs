using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSONFarseer;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Editor
{
    static class LevelManager
    {
        static LevelData CurrentLevel = null;
        static Color PhysicsColor = new Color(165, 255, 253, 100);

        public static bool HasSaved;
        public static string CurrentPath;

        public static void LoadLevel(string path)
        {
            string json;
            StreamReader reader = new StreamReader(path);
            CurrentPath = path;
            using (reader)
            {
                json = reader.ReadToEnd();
            }

            CurrentLevel = JsonConvert.DeserializeObject<LevelData>(json);
            HasSaved = true;

        }

        public static void SaveLevel(string path)
        {            
            string json = JsonConvert.SerializeObject(CurrentLevel);
            CurrentPath = path;
            StreamWriter writer = new StreamWriter(path, false);

            using (writer)
            {
                writer.Write(json);
            }

            HasSaved = true;
        }

        public static void CreateNewLevel()
        {
            CurrentLevel = new LevelData();
        }

        public static void MouseDown(Vector2 position)
        {

        }

        #region Editor functions

        public static void CreateRectangle()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;
            if (CurrentLevel != null)
            {
                CurrentLevel.Rectangles.Add(new PhysicsRectangle(new Vector2(10, 10), 100, 100, 0));
            }
        }

        #endregion



        public static void Update(float delta)
        {

        }

        public static void Draw(PrimitiveBatch primBatch, SpriteBatch spriteBatch)
        {
            if (CurrentLevel != null)
            {
                foreach (PhysicsRectangle rectangle in CurrentLevel.Rectangles)
                {
                    primBatch.DrawRectangle(true, rectangle.Position, rectangle.Width, rectangle.Height, rectangle.Rotation, PhysicsColor);
                }
            }
        }
    }
}

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
        static Color PhysicsColor = new Color(165, 255, 253, 150);
        static Color StartPointColor = new Color(164, 252, 148, 100);

        public static bool HasSaved;
        public static string CurrentPath;

        public static MouseMode Mousemode;

        static Vector2 rotatePoint = Vector2.Zero;

        static PhysicsRectangle tempRectangle = PhysicsRectangle.Empty;

        static StartPoint startPoint;

        static IDraggable CurrentObject = null;
        static Vector2 CurrentObjectOffset = Vector2.Zero;

        static LevelManager()
        {
            Mousemode = MouseMode.Select;
        }

        #region Loading and saving
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
            startPoint = new StartPoint(CurrentLevel.StartPosition);
        }

        public static void SaveLevel(string path)
        {
            CurrentLevel.StartPosition = startPoint.Position;
            string json = JsonConvert.SerializeObject(CurrentLevel, Formatting.Indented);
            CurrentPath = path;
            StreamWriter writer = new StreamWriter(path, false);

            using (writer)
            {
                writer.Write(json);
            }

            HasSaved = true;
        }
        #endregion

        public static void CreateNewLevel()
        {
            CurrentLevel = new LevelData();
            HasSaved = false;
            tempRectangle = PhysicsRectangle.Empty;
            startPoint = new StartPoint(new Vector2(0, 0));
        }

        public static void MouseDown(Vector2 position)
        {
            //lastMouseDownPos = position;
            switch (Mousemode)
            {
                case MouseMode.Select:
                    //if (GetCircleAABB(startPoint.Position, StartPoint.radius).Contains((int)position.X, (int)position.Y))
                    //startPoint.SetPosition(position);
                    if (GetCircleAABB(startPoint.Position, StartPoint.radius).ContainsVector(position))
                    //if (startPoint.ContainsPoint(position))
                    {
                        CurrentObject = startPoint;
                        CurrentObjectOffset =  CurrentObject.GetPosition() - position;
                    }
                    break;

                case MouseMode.DrawRectangle:
                    tempRectangle = new PhysicsRectangle(position, position *2, 0);
                    tempRectangle.TopLeft = position;
                    break;
                case MouseMode.DrawRectangleRotate:
                    //tempRectangle = new PhysicsRectangle(position, Vector2.Zero, 0);
                    tempRectangle.Rotation = (float)Math.Atan2(rotatePoint.Y - position.Y, rotatePoint.X - position.X);
                    CurrentLevel.Rectangles.Add(tempRectangle);
                    tempRectangle = PhysicsRectangle.Empty;
                    Mousemode = MouseMode.Select;
                    break;
            }
        }

        static Rectangle GetCircleAABB(Vector2 centre, float radius)
        {
            return new Rectangle((int)(centre.X - radius), (int)(centre.Y - radius), (int)(radius * 2), (int)(radius * 2));
        }

        public static void MouseUp(Vector2 position)
        {
            //lastMouseDownPos = position;
            switch (Mousemode)
            {
                case MouseMode.Select:
                    CurrentObject = null;
                    CurrentObjectOffset = Vector2.Zero;
                    break;

                case MouseMode.DrawRectangle:
                    tempRectangle.BottomRight = position;
                    tempRectangle.Width = Math.Abs(tempRectangle.Width);
                    tempRectangle.Height = Math.Abs(tempRectangle.Height);
                    //CurrentLevel.Rectangles.Add(tempRectangle);
                    //tempRectangle = PhysicsRectangle.Empty;
                    Mousemode = MouseMode.DrawRectangleRotate;
                    rotatePoint = tempRectangle.Position;
                    break;
            }
        }

        public static void MouseMove(Vector2 position)
        {
            switch (Mousemode)
            {
                case MouseMode.Select:
                    if (CurrentObject != null)
                        CurrentObject.SetPosition(position + CurrentObjectOffset);
                    break;

                case MouseMode.DrawRectangle:
                    tempRectangle.BottomRight = position;                    
                    break;

                case MouseMode.DrawRectangleRotate:
                    tempRectangle.Rotation = (float)Math.Atan2(rotatePoint.Y - position.Y, rotatePoint.X - position.X);
                    break;    
            }
        }

        #region Editor functions

        public static void CreateRectangle()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;
            if (CurrentLevel != null)
            {
                Mousemode = MouseMode.DrawRectangle;
                //CurrentLevel.Rectangles.Add(new PhysicsRectangle(new Vector2(10, 10), 100, 100, 0));
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
                    primBatch.DrawRectangle(false, rectangle.Position, rectangle.Width, rectangle.Height, rectangle.Rotation, Color.Black);
                }

                startPoint.Draw(primBatch);
                
            }
            else
            {
                //GraphicsDevice.
                spriteBatch.GraphicsDevice.Clear(Color.Black);
            }

            switch (Mousemode)
            {
                case MouseMode.DrawRectangle:
                    if (tempRectangle != PhysicsRectangle.Empty)
                        primBatch.DrawRectangleFromPoints(true, tempRectangle.TopLeft, tempRectangle.BottomRight, 0, PhysicsColor);
                    break;

                case MouseMode.DrawRectangleRotate:
                    //if (tempRectangle != PhysicsRectangle.Empty)
                        primBatch.DrawRectangle(true, tempRectangle.Position, tempRectangle.Size, tempRectangle.Rotation, PhysicsColor);
                    break;
            }       
        }
    }
}

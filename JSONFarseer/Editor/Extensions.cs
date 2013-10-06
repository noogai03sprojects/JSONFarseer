using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using JSONFarseer;

namespace Editor
{
    static class Extensions
    {
        /// <summary>
        /// Draws a circle. Requires PrimitiveBatch.Begin() and End(). Will auto-calculate whether it's filled or not.
        /// </summary>
        /// <param name="primitiveBatch"></param>
        /// <param name="position"></param>
        /// <param name="radius"></param>
        //public static void DrawCircle(this PrimitiveBatch primitiveBatch, Vector2 position, float radius, Color color)
        //{            

        //    //primitiveBatch.Begin(PrimitiveType.LineStrip);
        //    int steps = 20;
        //    float step = MathHelper.TwoPi / steps;
        //    switch (primitiveBatch.PrimitiveType)
        //    {
        //        case PrimitiveType.LineList:
                    
        //            for (int i = 0; i < (steps + 1); i++)
        //            {
        //                float x = radius * (float)Math.Cos(i * step);
        //                float y = radius * (float)Math.Sin(i * step);

        //                primitiveBatch.AddVertex(position + new Vector2(x, y), color);
        //                if (i != 0)                        
        //                    primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                        
        //            }
        //            break;
        //        case PrimitiveType.TriangleList:
        //            //int steps = 20;
        //            //float step = MathHelper.TwoPi / steps;
        //            for (int i = 0; i < (steps + 1); i++)
        //            {
        //                float x = radius * (float)Math.Cos(i * step);
        //                float y = radius * (float)Math.Sin(i * step);

                        
        //                if (i != 0)
        //                {
        //                    primitiveBatch.AddVertex(position + new Vector2(x, y), color);
        //                }

        //                primitiveBatch.AddVertex(position + new Vector2(x, y), color);
        //                primitiveBatch.AddVertex(position, color);

        //            }
        //            break;
        //    }

        //    //primitiveBatch.End();
        //}

        public static void DrawRectangle(this PrimitiveBatch primitiveBatch, bool filled, Rectangle rectangle, float rotation, Color color)
        {
            primitiveBatch.DrawRectangle(filled, new Vector2(rectangle.Center.X, rectangle.Center.Y), new Vector2(rectangle.Height, rectangle.Width), rotation, color);
        }

        public static void DrawRectangleFromPoints(this PrimitiveBatch primitiveBatch, bool filled, Vector2 topLeft, Vector2 bottomRight, float rotation, Color color)
        {
            primitiveBatch.DrawRectangle(filled, Vector2.Lerp(topLeft, bottomRight, 0.5f), bottomRight - topLeft, rotation, color);
        }

        public static void DrawRectangle(this PrimitiveBatch primitiveBatch, bool filled, Vector2 centre, Vector2 size, float rotation, Color color)
        {
            //Quaternion quat = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, rotation);
            //size = Vector2.Transform(size, quat);

            Vector2 halfSize = size / 2;
            Vector2 altHalfSize = new Vector2(halfSize.X, -halfSize.Y);

            Quaternion quat = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, rotation);
            halfSize = Vector2.Transform(halfSize, quat);
            altHalfSize = Vector2.Transform(altHalfSize, quat);
            //Vector2 topLeft = centre - halfSize;

            //Matrix rot = Matrix.CreateRotationZ(rotation);
            
            //size = Vector2.Transform(halfSize, quat);
            
            if (filled)
            {
                primitiveBatch.Begin(PrimitiveType.TriangleList);
                
                primitiveBatch.AddVertex(centre - halfSize, color);
                primitiveBatch.AddVertex(centre + altHalfSize, color);
                primitiveBatch.AddVertex(centre - altHalfSize, color);

                primitiveBatch.AddVertex(centre + halfSize, color);
                primitiveBatch.AddVertex(centre - altHalfSize, color);
                primitiveBatch.AddVertex(centre + altHalfSize, color);
                                

                primitiveBatch.End();
            }
            else
            {
                primitiveBatch.Begin(PrimitiveType.LineList);
                //top
                primitiveBatch.AddVertex(centre - halfSize, color);
                primitiveBatch.AddVertex(centre + altHalfSize, color);

                primitiveBatch.AddVertex(centre + altHalfSize, color);
                primitiveBatch.AddVertex(centre + halfSize, color);

                primitiveBatch.AddVertex(centre + halfSize, color);
                primitiveBatch.AddVertex(centre - altHalfSize, color);

                primitiveBatch.AddVertex(centre - altHalfSize, color);
                primitiveBatch.AddVertex(centre - halfSize, color);

                primitiveBatch.End();
            }
        }

        public static void DrawRectangle(this PrimitiveBatch primitiveBatch, bool filled, Vector2 centre, float width, float height, float rotation, Color color)
        {
            primitiveBatch.DrawRectangle(filled, centre, new Vector2(width, height), rotation, color);
        }

        public static void DrawCircle(this PrimitiveBatch primitiveBatch, Vector2 position, float radius, Color color)
        {
            primitiveBatch.Begin(PrimitiveType.LineList);
            int steps = 20;
            float step = MathHelper.TwoPi / steps;


            for (int i = 0; i < (steps + 1); i++)
            {
                float x = radius * (float)Math.Cos(i * step);
                float y = radius * (float)Math.Sin(i * step);

                primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                if (i != 0)
                    primitiveBatch.AddVertex(position + new Vector2(x, y), color);

            }
                    

            primitiveBatch.End();
        }

        public static void DrawFilledCircle(this PrimitiveBatch primitiveBatch, Vector2 position, float radius, Color color)
        {

            primitiveBatch.Begin(PrimitiveType.TriangleList);
            int steps = 20;
            float step = MathHelper.TwoPi / steps;           
                
                    
            for (int i = 0; i < (steps + 1); i++)
            {
                float x = radius * (float)Math.Cos(i * step);
                float y = radius * (float)Math.Sin(i * step);



                if (i != 0)
                {
                    primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                }

                if (i != steps)
                {
                    primitiveBatch.AddVertex(position, color);
                    primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                    
                }

            }                    

            primitiveBatch.End();
        }
    }
}

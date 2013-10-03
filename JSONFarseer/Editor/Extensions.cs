using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        public static void DrawCircle(this PrimitiveBatch primitiveBatch, Vector2 position, float radius, Color color)
        {            

            //primitiveBatch.Begin(PrimitiveType.LineStrip);
            int steps = 20;
            float step = MathHelper.TwoPi / steps;
            switch (primitiveBatch.PrimitiveType)
            {
                case PrimitiveType.LineList:
                    
                    for (int i = 0; i < (steps + 1); i++)
                    {
                        float x = radius * (float)Math.Cos(i * step);
                        float y = radius * (float)Math.Sin(i * step);

                        primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                        if (i != 0)                        
                            primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                        
                    }
                    break;
                case PrimitiveType.TriangleList:
                    //int steps = 20;
                    //float step = MathHelper.TwoPi / steps;
                    for (int i = 0; i < (steps + 1); i++)
                    {
                        float x = radius * (float)Math.Cos(i * step);
                        float y = radius * (float)Math.Sin(i * step);

                        
                        if (i != 0)
                        {
                            primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                        }

                        primitiveBatch.AddVertex(position + new Vector2(x, y), color);
                        primitiveBatch.AddVertex(position, color);

                    }
                    break;
            }

            //primitiveBatch.End();
        }
    }
}

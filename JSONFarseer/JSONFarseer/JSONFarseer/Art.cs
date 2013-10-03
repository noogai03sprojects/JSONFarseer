using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace JSONFarseer
{
    static class Art
    {
        public static Dictionary<int, Texture2D> Tileset = new Dictionary<int, Texture2D>();

        private static string ArtRoot;

        public static ContentManager Content;

        static Art()
        {
            ArtRoot = "gfx";
        }

        public static void Initialize(ContentManager content)
        {
            Content = content;
            //Content.
        }

        public static bool LoadTileset(Dictionary<int, string> tileset)
        {
            foreach (KeyValuePair<int, string> tile in tileset)
            {
                Texture2D tempImg = Content.Load<Texture2D>(ArtRoot + "\\" + tile.Value);
                Tileset.Add(tile.Key, tempImg);
            }
            return true;
        }
    }
}

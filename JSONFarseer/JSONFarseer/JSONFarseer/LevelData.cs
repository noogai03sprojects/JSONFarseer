using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONFarseer
{
    /// <summary>
    /// Level data to be serialized to and from JSON. Contains physics data; ALL VALUES MUST BE IN PIXELS AS THEY WILL BE CONVERTED TO METRES BY PHYSICSCORE
    /// </summary>
    public class LevelData
    {
        public List<PhysicsCircle> Circles;
        public List<PhysicsRectangle> Rectangles;

        public Dictionary<int, string> Tileset;

        public LevelData()
        {
            Circles = new List<PhysicsCircle>();
            Rectangles = new List<PhysicsRectangle>();

            Tileset = new Dictionary<int, string>();
        }
    }
}

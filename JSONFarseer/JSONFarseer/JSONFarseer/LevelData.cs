using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONFarseer
{
    /// <summary>
    /// Level data to be serialized to and from JSON. Contains physics data; ALL VALUES MUST BE IN PIXELS AS THEY WILL BE CONVERTED TO METRES BY PHYSICSCORE
    /// </summary>
    class LevelData
    {
        public PhysicsCircle[] Circles;
        public PhysicsRectangle[] Rectangles;

        public Dictionary<int, string> Tileset;
    }
}

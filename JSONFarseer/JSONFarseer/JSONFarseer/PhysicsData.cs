using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONFarseer
{
    class PhysicsData
    {
        public List<PhysicsCircle> Circles;
        public List<PhysicsRectangle> Rectangles;

        public PhysicsData()
        {
            Circles = new List<PhysicsCircle>();
            Rectangles = new List<PhysicsRectangle>();
        }
    }
}

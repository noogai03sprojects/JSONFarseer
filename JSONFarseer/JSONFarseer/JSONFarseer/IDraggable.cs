using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JSONFarseer
{
    public interface IDraggable
    {
        void SetPosition(Vector2 postion);

        Vector2 GetPosition();
    }
}

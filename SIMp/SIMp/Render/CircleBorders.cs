using SSSystemGenerator.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Render
{
    public class CircleBorders
    {

        public CircleBorders(int radius , Color color,int thickness)
        {
            this.radius = radius;
            this.color = color;
            this.thickness = thickness;
        }

        public int radius { get; set; }

        public Color color { get; set; }
        public int thickness { get; set; }
    }
}

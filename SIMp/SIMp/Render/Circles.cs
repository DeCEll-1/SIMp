﻿using SIMp.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SSSystemGenerator.Render
{
    public class Circles
    {
        public Circles() { }

        public Circles(PointF center, int radius, List<CircleBorders> borders, Color fillColor, bool filled)
        {
            Center = center;
            Radius = radius;
            Borders = borders;
            this.Borders = borders;
            InteriorColor = fillColor;
            Filled = filled;

            topLeft = new PointF(center.X - radius, center.Y - radius);

            topRight = new PointF(center.X + radius, center.Y + radius);

            bottomLeft = new PointF(center.X - radius, center.Y - radius);

            bottomRight = new PointF(center.X + radius, center.Y - radius);

        }

        public PointF Center { get; }

        public PointF topLeft { get; set; }
        public PointF topRight { get; set; }
        public PointF bottomLeft { get; set; }
        public PointF bottomRight { get; set; }

        public float Radius { get; }

        public List<CircleBorders> Borders { get; set; }

        public Color InteriorColor { get; }
        public bool Filled { get; }



    }
}

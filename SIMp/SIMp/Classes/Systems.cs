using SSSystemGenerator.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Classes
{
    public class Systems
    {

        public Systems(string systemColor, Point location)
        {
            this.location = location;


        }

        public int selectionRadius { get; set; } = 3;

        public int radius { get; set; } = 1;

        public Color systemColor { get; set; } = Color.FromArgb(255, 255, 255,255);

        public Point location { get; set; }

        public bool highLighted { get; set; } = false;

        public Color highLightColor { get; set; } = Color.Red;
    }
}

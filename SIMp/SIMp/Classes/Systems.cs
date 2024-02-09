using SIMp.Render;
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

            this.ID = location.X + "," + location.Y;

            highlights.Add(new Highlight(Color.Red, 3, hlTypeEnum.Selection, 1));
        }

        public string ID { get; set; } // loc as string

        public List<Highlight> highlights { get; set; } = new List<Highlight>();

        public int radius { get; set; } = 1;

        public Color systemColor { get; set; } = Color.FromArgb(255, 255, 255, 255);

        public Point location { get; set; }
    }
}
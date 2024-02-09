using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Render
{
    public class Highlight
    {

        public Highlight(Color color, int radius, hlTypeEnum type, int thickness)
        {
            this.color = color;
            this.radius = radius;
            this.type = type;
            this.thickness = thickness;
        }

        public hlTypeEnum type { get; set; }

        public Color color { get; set; }

        public int radius { get; set; }

        public int thickness { get; set; }
        
        public bool isActive {  get; set; } = false;


    }
}

public enum hlTypeEnum
{
    Selection,
}
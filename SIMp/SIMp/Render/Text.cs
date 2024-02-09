using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Render
{
    public class Text
    {

        public Text(string text, Font font, Brush brush, Point loc)
        {
            this.text = text;
            this.font = font;
            this.brush = brush;
            this.loc = loc;

        }

        public string text { get; set; }

        public Font font { get; set; }

        public Brush brush { get; set; }

        public Point loc { get; set; }

    }
}

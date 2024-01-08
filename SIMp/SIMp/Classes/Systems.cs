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

        public Systems(string systemColor, PointF location)
        {
            this.location = location;

            switch (systemColor)
            {
                case "Red":
                    this.systemColor = Color.Red;
                    break;
                case "Green":
                    this.systemColor = Color.Green;
                    break;
                case "Blue":
                    this.systemColor = Color.Blue;
                    break;

                case "Orange":
                    this.systemColor = Color.Orange;
                    break;
                case "Yellow":
                    this.systemColor = Color.Yellow;
                    break;
                case "Purple":
                    this.systemColor = Color.Purple;
                    break;

                case "White":
                    this.systemColor = Color.White;
                    break;

                default: throw new Exception("bruh");
            }
        }

        public Color systemColor { get; set; }

        public PointF location { get; set; }
    }
}

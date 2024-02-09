using SIMp.Classes;
using SSSystemGenerator.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSystemGenerator.Classes
{
    public class Statics
    {
        public static DirectoryInfo EXEPath { get; set; } = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        public static DirectoryInfo SystemLocJsonDir { get; set; } = new DirectoryInfo(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).//debug
            Parent.//bin
            Parent.FullName + "\\Resources\\SystemDataOutput.json");//SIMp

        public static DirectoryInfo SystemDataJsonDir { get; set; } = new DirectoryInfo(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).//debug
            Parent.//bin
            Parent.FullName + "\\Resources\\SystemData.json");//SIMp

        public static List<Systems> systemList = new List<Systems>();

        public static List<SystemData> systemDataList = new List<SystemData>();

        public const string Version = "0" + "." + "0" + "." + "2";

        public static Map Map { get; set; } = null;
        public static BaseMDIContainer BaseMDIContainer { get; set; } = null;

        public static Dictionary<string, string[]> Lines { get; set; } = new Dictionary<string, string[]>();

        public static Dictionary<string, Color> colorMap { get; } = new Dictionary<string, Color>()
        {
            {"wild",Color.Purple},
            {"unsecure",Color.Red},
            {"core",Color.Green},
            {"secure",Color.Blue},
        };


        public static Color systemConnectionColor { get; set; } = Color.Gray;


    }
}

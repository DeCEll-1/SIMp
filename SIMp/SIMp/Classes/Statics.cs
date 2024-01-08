using SIMp.Classes;
using SSSystemGenerator.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSystemGenerator.Classes
{
    public class Statics
    {
        public static DirectoryInfo EXEPath { get; set; } = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        public static DirectoryInfo JSONPath { get; set; } = new DirectoryInfo(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).//debug
            Parent.//bin
            Parent.//SIMp
            Parent.//SIMp
            Parent.FullName + "\\SystemDataOutput.json");//SIMp

        public static List<Systems> systemList = new List<Systems>();

        public const string Version = "0" + "." + "0" + "." + "2";

        public static Map Map { get; set; } = null;
        public static BaseMDIContainer BaseMDIContainer { get; set; } = null;

    }
}

using SSSystemGenerator;
using SSSystemGenerator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Statics.BaseMDIContainer = new BaseMDIContainer();

            Statics.systemList = JsonHelper.returnListOfSystems();


            Application.Run(Statics.BaseMDIContainer);
        }
    }
}

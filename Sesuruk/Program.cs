using System;
using System.Windows.Forms;
using Sesuruk.Functions;

namespace Sesuruk
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(new Sound(), new Settings()));
        }
    }
}

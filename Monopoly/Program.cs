using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace Monopoly
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Board b = new Board(false);
            b.languageSelect();
            b.determinePlayerLabels();
            b.updatePlayerLabels();
            Application.Run(b);
        }
    }
}

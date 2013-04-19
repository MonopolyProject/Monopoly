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

            Railroad r = new Railroad("Pennsylvania Railroad", 15, new Player("Ben"), 200, 100);

            Console.WriteLine(r.GetType().ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Board());
        }
    }
}

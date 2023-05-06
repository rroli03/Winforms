using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotcakes_orders
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
            Application.Run(new Form1());
            
            //Ha nincs internet épp, és tesztelni szeretnénk a programot futás közben, akkor a TestableApi-val kell indítani.
            //Application.Run(new Form1(new TestableApi()));
        }
    }
}

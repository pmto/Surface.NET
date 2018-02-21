// Surface.NET/Surface.NET Classic/Program.cs
// 21.02.2018 14:42
// Cosmos Romantica (Александр Гелета) <mycatshoegazer@outlook.com>

using System;
using System.Windows.Forms;

namespace SurfaceClassic
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIMainForm());
        }
    }
}
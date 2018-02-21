// Surface.NET/Surface.NET Classic/Program.cs
// 21.02.2018 14:42
// Cosmos Romantica (Александр Гелета) <mycatshoegazer@outlook.com>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using SurfaceClassic.Properties;

namespace SurfaceClassic {
    internal static class Program {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main() {
#if DEBUG
            Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName}: Started...");
#else
            if (!EventLog.SourceExists(Settings.Default.AppName))
                EventLog.CreateEventSource(Settings.Default.AppName, "Application");

            EventLog.WriteEntry(Settings.Default.AppName, "Started application", EventLogEntryType.Information);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIMainForm());
        }
    }
}
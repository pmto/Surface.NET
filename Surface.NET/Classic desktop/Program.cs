// Surface.NET, Surface.NET Classic
// Copyright (C) 2018  MyCatShoegazer
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// FILE: Surface.NET/Surface.NET Classic/Program.cs
// MODIFIED: 21.02.2018 14:42
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

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
            if (!EventLog.SourceExists(Settings.Default.AppName))
                EventLog.CreateEventSource(Settings.Default.AppName, "Application");

            EventLog.WriteEntry(Settings.Default.AppName, "Started application", EventLogEntryType.Information);

            Application.ApplicationExit += (sender, args) => {
                EventLog.WriteEntry(Settings.Default.AppName, "Application exited...", EventLogEntryType.Information);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIMainForm());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SurfaceDesktop.Properties;
using SurfaceDesktop.Resources.Localization;

namespace Surface.NET_Desktop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e) {
            try {
                Settings.Default.Save();
            }
            catch (Exception) {
                MessageBox.Show(LocalizedStrings.ApplicationSaveSettingsErrorMessageText,
                    LocalizedStrings.ApplicationSaveSettingsErrorMessageTitle, MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}

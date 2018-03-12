using System;
using System.Windows;
using SurfaceDesktop.Properties;
using SurfaceDesktop.Resources.Localization;

namespace SurfaceDesktop {
    /// <summary>
    ///     Application entry point.
    /// </summary>
    public partial class App : Application {
        /// <summary>
        ///     Rises when application doing exit.
        /// </summary>
        private void App_OnExit(object sender, ExitEventArgs e) {
            SaveSettings();
        }

        /// <summary>
        ///     Save settings and avoid application crush on errors.
        /// </summary>
        private static void SaveSettings() {
            /*
             * Here we trying to save application changes
             * and if it goes to error then showing WinForms message to user.
             */
            try {
                // Saving application settings
                Settings.Default.Save();
            }
            catch (Exception) {
                // Show message on errors
                MessageBox.Show(LocalizedStrings.ApplicationSaveSettingsErrorMessageText,
                    LocalizedStrings.ApplicationSaveSettingsErrorMessageTitle, MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     Rises when application starting.
        /// </summary>
        private void App_OnStartup(object sender, StartupEventArgs e) {
            /*
             * Here on application startup we registering event handler
             * which rises when settings changed.
             */
            Settings.Default.PropertyChanged += (o, args) => {
                // Saving changes
                SaveSettings();
            };
        }
    }
}
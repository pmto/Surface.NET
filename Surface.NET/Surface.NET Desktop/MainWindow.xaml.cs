using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SurfaceDesktop.Properties;
using SurfaceDesktop.Resources.Localization;

namespace SurfaceDesktop {
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            this.LocalesDictionary = new Dictionary<string, string> {
                {"English", "en-US"},
                {"Russian", "ru-RU"},
                {"German", "de-DE"},
                {"Korean (South)", "ko-KR"},
                {"Ukranian", "uk-UA"}
            };

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.CurrentLocale);

            this.InitializeComponent();

            var selectedKey = this.LocalesDictionary.FirstOrDefault(x => x.Value == Settings.Default.CurrentLocale);
            this.LanguageSplitButton.SelectedItem = selectedKey;
        }

        public Dictionary<string, string> LocalesDictionary { get; set; }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e) {
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }

        private async void LanguageSplitButton_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedItem = (KeyValuePair<string, string>) this.LanguageSplitButton.SelectedItem;

            if (this.LocalesDictionary.TryGetValue(selectedItem.Key, out var value)) {
                if (Settings.Default.CurrentLocale.Equals(value)) return;

                Settings.Default.CurrentLocale = value;
                Settings.Default.Save();

                if (await this.ShowMessageAsync(LocalizedStrings.ApplicationRestartMessageTitle,
                        LocalizedStrings.ApplicationRestartMessageText, MessageDialogStyle.AffirmativeAndNegative) !=
                    MessageDialogResult.Affirmative) return;

                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else {
                await this.ShowMessageAsync(LocalizedStrings.ApplicationSaveSettingsErrorMessageTitle,
                    LocalizedStrings.ApplicationSaveSettingsErrorMessageText);
            }
        }
    }
}
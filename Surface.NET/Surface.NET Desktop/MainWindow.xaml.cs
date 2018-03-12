using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    ///     This is the main application window class.
    /// </summary>
    public partial class MainWindow : MetroWindow {
        #region costructors

        public MainWindow() {
            /*
             * Fill the dictionary with application supported locales,
             * where key is locale name and value is locale code.
             */
            this.LocalesDictionary = new Dictionary<string, string> {
                {"English", "en-US"},
                {"Russian", "ru-RU"},
                {"German", "de-DE"},
                {"Korean (South)", "ko-KR"},
                {"Ukranian", "uk-UA"}
            };

            /*
             * Fill this collection with flyout supported themes.
             */
            this.FlyoutThemes = new ObservableCollection<FlyoutTheme> {
                FlyoutTheme.Adapt,
                FlyoutTheme.Accent,
                FlyoutTheme.Dark,
                FlyoutTheme.Light,
                FlyoutTheme.Inverse
            };

            /*
             * Applying application ui locale from saved instance in project settings.
             * It is important to do this before initializing component!
             */
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.CurrentLocale);

            // Initialization application main window with all of it's components.
            this.InitializeComponent();

            /*
             * Searching current saved application locale code from project settings
             * and setting it as selected item in language selection split button.
             */
            var selectedKey = this.LocalesDictionary.FirstOrDefault(x => x.Value == Settings.Default.CurrentLocale);
            this.LanguageSplitButton.SelectedItem = selectedKey;
        }

        #endregion

        #region properties

        /// <summary>
        ///     Contains application supported translations,
        ///     <para>
        ///         where Key - locale name and Value - locale code.
        ///     </para>
        /// </summary>
        public Dictionary<string, string> LocalesDictionary { get; set; }

        /// <summary>
        ///     Contains flyout themes variations.
        /// </summary>
        public ObservableCollection<FlyoutTheme> FlyoutThemes { get; set; }

        #endregion

        #region events

        /// <summary>
        ///     Changes open state of setting flyout control.
        /// </summary>
        private void SettingsButton_OnClick(object sender, RoutedEventArgs e) {
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }

        /// <summary>
        ///     Sets current application UI localization and causes restart.
        /// </summary>
        private async void LanguageSplitButton_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Taking selected locale item from language selection split button
            var selectedItem = (KeyValuePair<string, string>) this.LanguageSplitButton.SelectedItem;

            /*
             * Here we test if application supported locale dictionary contains
             * selected locale code presented by key property from language selection split button
             * and taking it into value inline variable.
             */
            if (this.LocalesDictionary.TryGetValue(selectedItem.Key, out var value)) {
                /*
                 * Cheking if locale code presented in value variable is already
                 * saved in project settings. If it is true then returning from method.
                 * This is needed to prevent next code execution because this event
                 * rises even when language selection split button is filling from application
                 * supported locales.
                 */
                if (Settings.Default.CurrentLocale.Equals(value)) return;

                /*
                 * Setting current application locale to new from value variable.
                 * Then saving application settings.
                 */
                Settings.Default.CurrentLocale = value;

                /*
                 * Here we asking user to accept restarting of application
                 * to make new setting work properly and also to reload UI for
                 * new locale.
                 * If user canceled then returning from method.
                 */
                if (await this.ShowMessageAsync(LocalizedStrings.ApplicationRestartMessageTitle,
                        LocalizedStrings.ApplicationRestartMessageText, MessageDialogStyle.AffirmativeAndNegative) !=
                    MessageDialogResult.Affirmative) return;

                /*
                 * Because of WPF changes we don't have ability to restart application
                 * using Application.Restart();. Now we need to start new process of this
                 * application and kill current active.
                 */
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else {
                /*
                 * Show error message if we catch in error while
                 * changing application settings.
                 */
                await this.ShowMessageAsync(LocalizedStrings.ApplicationSaveSettingsErrorMessageTitle,
                    LocalizedStrings.ApplicationSaveSettingsErrorMessageText);
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace SurfaceDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public Dictionary<string, string> LocalesDictionary { get; set; }

        public MainWindow()
        {
            this.LocalesDictionary = new Dictionary<string, string> {
                { "English", "en-US" },
                { "Russian", "ru-RU" },
                { "German", "de-DE" },
                { "Korean (South)", "ko-KR" },
                { "Ukranian", "uk-UA" }
            };

            this.InitializeComponent();
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e) {
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }
    }
}

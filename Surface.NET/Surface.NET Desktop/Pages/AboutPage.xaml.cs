using System.Reflection;
using System.Windows.Controls;

namespace SurfaceDesktop.Pages {
    /// <summary>
    ///     <see cref="AboutPage"/> logic.
    /// </summary>
    public partial class AboutPage : Page {
        public AboutPage() {
            // Initialize page components
            this.InitializeComponent();
            
            // Load assembly info to controls
            this.LoadAssemblyInfo();
        }

        /// <summary>
        ///     Loads assembly info to page controls of current application
        ///     using reflection mechanism.
        /// </summary>
        private void LoadAssemblyInfo() {
            var application = Assembly.GetExecutingAssembly();

            this.TitleTextBox.Text =
                ((AssemblyTitleAttribute) application.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0])
                .Title;
            this.CompanyTextBox.Text =
                ((AssemblyCompanyAttribute) application.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0])
                .Company;
            this.ProductTextBox.Text =
                ((AssemblyProductAttribute) application.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0])
                .Product;
            this.CopyrightTextBox.Text =
                ((AssemblyCopyrightAttribute) application.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                    [0])
                .Copyright;
            this.TrademarkTextBox.Text =
                ((AssemblyTrademarkAttribute) application.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false)
                    [0])
                .Trademark;
            this.VersionTextBox.Text =
                ((AssemblyVersionAttribute) application.GetCustomAttributes(typeof(AssemblyVersionAttribute), false)[0])
                .Version;
        }
    }
}
using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Product_Manual_Center
{
    public partial class AppWindow : Form
    {
        // Instance of the WebView2 control
        private WebView2 webView;
        // Initializes a new instance of Form.
        public AppWindow()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            InitializeWebView();
        }
        // Asynchronously initializes the WebView2 control, setting up its environment and loading the default URL.
        private async void InitializeWebView()
        {
            try
            {
                // Create a new WebView2 instance and dock it to fill the form
                webView = new WebView2
                {
                    Dock = DockStyle.Fill
                };
                // Add the WebView2 to the Controls collection
                this.Controls.Add(webView);
                // Define a unique UserDataFolder path for the current user
                string userSpecificFolder = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Product_Manual_Center_WebView2",
                    Environment.UserName
                );
                // Create a WebView2 environment using the unique folder
                var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: userSpecificFolder);
                await webView.EnsureCoreWebView2Async(env);
                // Define the URL to navigate to
                string url = "https://center.productmanualcenter.com";
                // Navigate to the URL
                webView.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopWrapper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Extra configuration
        webView.CoreWebView2InitializationCompleted += SetExtraConfiguration;

        //App.Self.ServerUrl;

        webView.Source = new Uri(App.Self.ServerUrl ?? "");
    }

    private void SetExtraConfiguration(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        if (!e.IsSuccess) return;

        webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
    }
}
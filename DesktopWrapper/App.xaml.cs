using System.Configuration;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using System.Security.Policy;
using System.Diagnostics;

namespace DesktopWrapper;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static App Self => ((App)Application.Current);

    public string? ServerUrl { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Search for available localhost port
        var udp = new UdpClient(0, AddressFamily.InterNetwork);
        int? port = ((IPEndPoint?) udp.Client?.LocalEndPoint)?.Port ?? 5055;

        this.ServerUrl = $"http://localhost:{port}";
        Debug.WriteLine($"Starting server at: {this.ServerUrl}");

        // launch web server
        new Thread(() => new StaticFileServer().Start(this.ServerUrl))
        {
            IsBackground = true
        }.Start();
    }
}


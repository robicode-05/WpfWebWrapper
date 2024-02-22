using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;

public class StaticFileServer
{
    private readonly WebApplication _webApp;

    public StaticFileServer()
    {
         //_webApp = WebHost.CreateDefaultBuilder()
         //  .Configure(config => config.UseStaticFiles())
         //  .UseWebRoot("wwwroot")
         //  .UseUrls([url])
         //  .Build();

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDirectoryBrowser();
        _webApp = builder.Build();
        _webApp.UseFileServer(enableDirectoryBrowsing: true);

    }

    public int Start(string url)
    {
        _webApp.Run(url);
        return 0;
    }

    public int Stop()
    {
        _webApp.StopAsync();
        return 0;
    }
}

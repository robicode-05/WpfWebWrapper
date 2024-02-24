using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;

public class StaticFileServer
{
    private readonly WebApplication _webApp;

    public StaticFileServer(string url)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDirectoryBrowser();
        builder.Environment.ContentRootPath = "wwwroot";
        _webApp = builder.Build();
        _webApp.Urls.Add(url);
        _webApp.UseFileServer(enableDirectoryBrowsing: true);
    }

    public int Start()
    {
        _webApp.Run();
        return 0;
    }

    public int Stop()
    {
        _webApp.StopAsync();
        return 0;
    }
}

using Microsoft.AspNetCore;

public class StaticFileServer
{
    private readonly WebApplication _webApp;

    public StaticFileServer()
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            WebRootPath = "wwwroot",
        });
        builder.Services.AddDirectoryBrowser();
       
        _webApp = builder.Build();


        _webApp.UseStaticFiles();
        _webApp.UseDefaultFiles();
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

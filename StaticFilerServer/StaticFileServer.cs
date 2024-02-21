public class StaticFileServer
{
    private readonly WebApplication _webApp;


    public StaticFileServer()
    {
        var builder = WebApplication.CreateBuilder();
        _webApp = builder.Build();

        _webApp.MapGet("/", () => "Hello World!");
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

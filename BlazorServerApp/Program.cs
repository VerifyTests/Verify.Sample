using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main()
    {
        CreateHostBuilder().Build().Run();
    }

    static IHostBuilder CreateHostBuilder()
    {
        var hostBuilder = Host.CreateDefaultBuilder();
        return hostBuilder.ConfigureWebHostDefaults(_ => { _.UseStartup<Startup>(); });
    }
}
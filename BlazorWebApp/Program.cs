using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebApp;

class Program
{
    static async Task Main()
    {
        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<App>("#app");
        await builder.Build().RunAsync();
    }
}
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Thunder.WebView.Blazor;
using Thunder.WebView.Windows;

namespace Thunder.WebView.Tests
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
               .UseWebView<Startup>( builder => builder
                    .UseBlazor()
                    .UseSSL(true)
                    .UseWindowsForms())
               .Build()
               .RunAsync();
        }
    }
}

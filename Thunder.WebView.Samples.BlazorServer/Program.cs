using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Thunder.WebView.Blazor;
using Thunder.WebView.Windows;

namespace Thunder.WebView.Samples.BlazorServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
               .UseWebView<Startup>(builder => builder
                   .UseSSL(true)
                   .UseWindowsForms())
               .Build()
               .RunAsync();
        }
    }
}

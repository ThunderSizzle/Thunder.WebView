using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Thunder.WebView
{
    public static class UseWebViewHostBuilderExtensions
    {
        public static IHostBuilder UseWebView<TStartup>(this IHostBuilder hostBuilder)
            where TStartup : class
        {
            //todo replace this with dynamic port look up
            var urls = new[] { "http://localhost:5000", "https://localhost:5001" };

            return hostBuilder
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                    .UseStartup<TStartup>()
                    .UseUrls(urls)
                    .UseKestrel();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // todo determine which url to prefer
                    var primaryUrl = urls.Last();
                    // todo plugin primary URL into WebView2

                    services.AddSingleton<WebViewForm>();
                    services.AddSingleton(c => new ApplicationContext(c.GetRequiredService<WebViewForm>()));
                    services.AddSingleton<IHostLifetime, WindowsFormsLifetime>();
                    services.AddHostedService<WindowsFormsApplicationHostedService>();
                });
        }
    }
}

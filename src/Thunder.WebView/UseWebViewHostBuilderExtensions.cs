using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Thunder.WebView
{
    public static class UseWebViewHostBuilderExtensions
    {
        public static IHostBuilder UseWebView<TStartup>(this IHostBuilder hostBuilder, Action<IWebViewBuilder> buildWebViewAction)
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
                    var builder = new WebViewBuilder(services);
                    buildWebViewAction(builder);

                    var primaryUrl = builder.WebViewOptions.UseSSL ? urls.Last() : urls.First();
                    builder.UseUrl(primaryUrl);
                    services.AddSingleton(sp => builder.GetOptions());
                });
        }
    }
}

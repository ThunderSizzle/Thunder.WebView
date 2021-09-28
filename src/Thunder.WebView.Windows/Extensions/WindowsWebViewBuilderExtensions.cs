using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using Thunder.WebView.Messaging;

namespace Thunder.WebView.Windows
{
    public static class WindowsWebViewBuilderExtensions
    {
        public static IWebViewBuilder UseWindowsForms(this IWebViewBuilder builder)
        {
            builder.Services.AddSingleton<WebViewForm>();
            builder.Services.AddSingleton<IMessagingWebView>(x => x.GetRequiredService<WebViewForm>());
            builder.Services.AddSingleton(c => new ApplicationContext(c.GetRequiredService<WebViewForm>()));
            builder.Services.AddSingleton<IHostLifetime, WindowsFormsLifetime>();
            builder.Services.AddHostedService<WindowsFormsApplicationHostedService>();

            return builder;
        }
    }
}

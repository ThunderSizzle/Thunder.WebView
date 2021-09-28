using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;

namespace Thunder.WebView.Windows
{
    internal static class WindowsWebViewBuilderExtensions
    {
        internal static IWebViewBuilder UseWindowsForms(this IWebViewBuilder builder)
        {
            builder.Services.AddSingleton<WebViewForm>();
            builder.Services.AddSingleton(c => new ApplicationContext(c.GetRequiredService<WebViewForm>()));
            builder.Services.AddSingleton<IHostLifetime, WindowsFormsLifetime>();
            builder.Services.AddHostedService<WindowsFormsApplicationHostedService>();

            return builder;
        }
    }
}

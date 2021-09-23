using Microsoft.Extensions.DependencyInjection;

namespace Thunder.WebView
{
    public interface IWebViewBuilder
    {
        IServiceCollection Services { get; }
        WebViewOptions WebViewOptions { get; }
    }
}

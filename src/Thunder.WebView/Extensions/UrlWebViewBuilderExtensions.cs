using System;

namespace Thunder.WebView
{
    internal static class UrlWebViewBuilderExtensions
    {
        internal static IWebViewBuilder UseUrl(this IWebViewBuilder builder, String url)
        {
            builder.WebViewOptions.StartingUrl = url;
            return builder;
        }
    }
}

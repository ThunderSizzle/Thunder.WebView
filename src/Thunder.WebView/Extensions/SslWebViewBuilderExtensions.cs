using System;

namespace Thunder.WebView
{
    public static class SslWebViewBuilderExtensions
    {
        public static IWebViewBuilder UseSSL(this IWebViewBuilder builder, Boolean useSSL)
        {
            builder.WebViewOptions.UseSSL = useSSL;
            return builder;
        }
    }
}

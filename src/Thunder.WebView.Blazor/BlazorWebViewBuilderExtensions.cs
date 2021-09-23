using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder.WebView.Blazor
{
    public static class BlazorWebViewBuilderExtensions
    {
        public static IWebViewBuilder UseBlazor(this IWebViewBuilder webViewBuilder)
        {
            //todo - specify services required for Blazor to run in a WebView properly
            return webViewBuilder;
        }
    }
}

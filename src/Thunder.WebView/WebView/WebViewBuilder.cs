using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Options;

namespace Thunder.WebView
{
    internal class WebViewBuilder : IWebViewBuilder
    {
        public WebViewBuilder(IServiceCollection services) => this.Services = services;

        public IServiceCollection Services { get; }
        public WebViewOptions WebViewOptions { get; } = new();

        public IOptions<WebViewOptions> GetOptions()
        {
            return Options.Create(this.WebViewOptions);
        }
    }
}

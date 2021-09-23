using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Thunder.WebView.Tests
{
    public class TestStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            var html = File.ReadAllText("Motherfucking Website.html");
            app.Run(context => context.Response.WriteAsync(html));
        }
        public void ConfigureServices(IServiceCollection _)
        {
        }
    }
}

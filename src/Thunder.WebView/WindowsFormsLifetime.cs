using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting.Internal;

namespace Thunder.WebView
{
    public class WindowsFormsLifetime : IHostLifetime, IDisposable
    {
        private readonly IHostApplicationLifetime _applicationLifetime;

        public WindowsFormsLifetime(IHostApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }
        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            Application.ApplicationExit += OnExit;
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Application.ApplicationExit -= OnExit;
        }
        private void OnExit(object sender, EventArgs e)
        {
            _applicationLifetime.StopApplication();
            System.Environment.ExitCode = 0;
        }
    }
}

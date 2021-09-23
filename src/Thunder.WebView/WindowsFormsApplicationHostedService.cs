using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thunder.WebView
{
    public class WindowsFormsApplicationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Thread _thread;

        public WindowsFormsApplicationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            // The thread hosting the Windows Forms application needs to have an STA apartment state
            _thread = new Thread(UIThreadStart);
            _thread.SetApartmentState(ApartmentState.STA);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // we wait to start the thread until the app actually starts
            _thread.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void UIThreadStart()
        {
            // just get the application context and attempt to run it when the thread starts
            var applicationContext = _serviceProvider.GetRequiredService<ApplicationContext>();
            Application.Run(applicationContext);
        }
    }
}

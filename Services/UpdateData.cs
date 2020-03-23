using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestRazorPages.Services
{

    public class UpdateData : IHostedService, IDisposable
    {
        private readonly ILogger<UpdateData> _logger;
        private Timer _timer;
        private readonly TestService _testService;

        public UpdateData(ILogger<UpdateData> logger, TestService testService)
        {
            _logger = logger;
            _testService = testService;
        }


        private void DoWork(object state)
        {
            _testService.UpdateValue();

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Value}", _testService.GetValue());
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
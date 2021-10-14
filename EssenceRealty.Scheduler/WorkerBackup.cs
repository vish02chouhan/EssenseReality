using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Scheduler.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler
{
    public class WorkerBackup : IHostedService, IDisposable
    {
        private readonly ILogger<WorkerBackup> _logger;
        private readonly VaultCrmProcessor vaultCrmProcessor;
        private readonly LogTransactionProcessor logTransactionProcessor;
        private Timer _timer;

        public WorkerBackup(ILogger<WorkerBackup> logger,
            VaultCrmProcessor vaultCrmProcessor,
            LogTransactionProcessor logTransactionProcessor)
        {
            _logger = logger;
            this.vaultCrmProcessor = vaultCrmProcessor;
            this.logTransactionProcessor = logTransactionProcessor;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(OnTimer, cancellationToken, TimeSpan.FromSeconds(60), TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void OnTimer(object state)
        {
            _logger.LogInformation("OnTimer event called");
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            Guid batchUniqueId = Guid.NewGuid();
            await vaultCrmProcessor.StartProcessing(batchUniqueId);
            await logTransactionProcessor.StartProcessing(batchUniqueId); //Guid.Parse("13AD1F0E-87CA-4B7C-8189-113BC9636C74"));// batchUniqueId);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync Called");
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Dispose Called");
            _timer?.Dispose();
        }


        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //while (!stoppingToken.IsCancellationRequested)
        //{
        //       _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        //Guid batchUniqueId = Guid.NewGuid();
        // await vaultCrmProcessor.StartProcessing(batchUniqueId);
        //await logTransactionProcessor.StartProcessing(batchUniqueId); //Guid.Parse("13AD1F0E-87CA-4B7C-8189-113BC9636C74"));// batchUniqueId);

        ///await Task.Delay(1000, stoppingToken);
        //}
        //}
    }
}

//Commands

//    dotnet publish -r win-x64 -o c:\publish\win-service /p:PublishSingleFile = true /p:DebugType = None

//    sc create EssenceDataProcessor binPath=C:\publish\win - service\EssenceRealty.Scheduler.exe start = delayed - auto

//    sc delete

// sc create TenniseDataProcessor binPath=C:\publish\win-service\TennisBookings.ScoreProcessor.exe start= delayed-auto
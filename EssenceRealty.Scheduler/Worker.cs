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
using Serilog;
using Microsoft.Extensions.Options;

namespace EssenceRealty.Scheduler
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly ILogger<Worker> _logger;
        private readonly VaultCrmProcessor vaultCrmProcessor;
        private readonly LogTransactionProcessor logTransactionProcessor;
        private readonly VaultServicesConfig vaultServicesConfig;
        private Timer _timer;

        public Worker(ILogger<Worker> logger,
            VaultCrmProcessor vaultCrmProcessor,
            LogTransactionProcessor logTransactionProcessor,
            IOptions<VaultServicesConfig> vaultServicesConfig)
        {
            _logger = logger;
            this.vaultCrmProcessor = vaultCrmProcessor;
            this.logTransactionProcessor = logTransactionProcessor;
            this.vaultServicesConfig = vaultServicesConfig.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(OnTimer, cancellationToken, TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(vaultServicesConfig.SchedulerInterval));
            return Task.CompletedTask;
        }

        private async void OnTimer(object state)
        {
            Log.Information("OnTimer event called");
            Log.Information("Worker running at: {time}", DateTimeOffset.Now);

            Guid batchUniqueId = Guid.NewGuid();
            await vaultCrmProcessor.StartProcessing(batchUniqueId);
            await logTransactionProcessor.StartProcessing(batchUniqueId,vaultCrmProcessor); //Guid.Parse("13AD1F0E-87CA-4B7C-8189-113BC9636C74"));// batchUniqueId);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("StopAsync Called");
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
             Log.Information("Dispose Called");
            _timer?.Dispose();
        }

    }
}

//Commands

//    dotnet publish -r win-x64 -o c:\publish\win-service /p:PublishSingleFile = true /p:DebugType = None

//    sc create EssenceDataProcessor binPath=C:\publish\win-service\EssenceRealty.Scheduler.exe start = delayed-auto

//    sc delete

// sc create TenniseDataProcessor binPath=C:\publish\win-service\TennisBookings.ScoreProcessor.exe start= delayed-auto
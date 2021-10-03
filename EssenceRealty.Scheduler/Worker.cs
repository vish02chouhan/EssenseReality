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
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly VaultCrmProcessor vaultCrmProcessor;
        private readonly LogTransactionProcessor logTransactionProcessor;

        public Worker(ILogger<Worker> logger,
            VaultCrmProcessor vaultCrmProcessor,
            LogTransactionProcessor logTransactionProcessor)
        {
            _logger = logger;
            this.vaultCrmProcessor = vaultCrmProcessor;
            this.logTransactionProcessor = logTransactionProcessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                Guid batchUniqueId = Guid.NewGuid();
                //await vaultCrmProcessor.StartProcessing(batchUniqueId);
                await logTransactionProcessor.StartProcessing(Guid.Parse("E53B1AC6-CB41-4333-A124-917D7C3C0239"));// batchUniqueId);

                ///await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
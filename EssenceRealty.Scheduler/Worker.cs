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
            //while (!stoppingToken.IsCancellationRequested)
            //{
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                Guid batchUniqueId = Guid.NewGuid();
            await vaultCrmProcessor.StartProcessing(batchUniqueId);
            await logTransactionProcessor.StartProcessing(batchUniqueId);//Guid.Parse("804fe586-1677-4107-82b5-92d0431f5b9d"));// 

            ///await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}

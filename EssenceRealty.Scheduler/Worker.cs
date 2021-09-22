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

        public Worker(ILogger<Worker> logger,
            VaultCrmProcessor vaultCrmProcessor)
        {
            _logger = logger;
            this.vaultCrmProcessor = vaultCrmProcessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await vaultCrmProcessor.StartProcessing(Guid.NewGuid());

                ///await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

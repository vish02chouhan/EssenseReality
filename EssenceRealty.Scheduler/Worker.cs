using EssenceRealty.Scheduler.Configurations;
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
        private readonly VaultServicesConfig _vaultServicesConfig;

        public Worker(ILogger<Worker> logger,
            VaultServicesConfig vaultServicesConfig)
        {
            _logger = logger;
            _vaultServicesConfig = vaultServicesConfig;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

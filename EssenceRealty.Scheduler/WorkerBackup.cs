using EssenceRealty.Scheduler.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler
{
    public class WorkerBackUp : BackgroundService
    {

        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        private readonly ILogger<WorkerBackUp> _logger;
        private readonly VaultCrmProcessor vaultCrmProcessor;
        private readonly LogTransactionProcessor logTransactionProcessor;
        private Timer _timer;

        public WorkerBackUp(ILogger<WorkerBackUp> logger,
            VaultCrmProcessor vaultCrmProcessor,
            LogTransactionProcessor logTransactionProcessor,
             IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            this.vaultCrmProcessor = vaultCrmProcessor;
            this.logTransactionProcessor = logTransactionProcessor;
        }



        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() =>
            {
                _logger.LogInformation("Ending score processing.");
            });

            try
            {
                Guid batchUniqueId = Guid.NewGuid();
                await vaultCrmProcessor.StartProcessing(batchUniqueId);
                await logTransactionProcessor.StartProcessing(batchUniqueId);

                System.Threading.Thread.Sleep(300000);
            }
            catch (OperationCanceledException)
            {
                // Swallow this since we expect this to occur when shutdown has been signalled.
                _logger.OperationCancelledExceptionOccurred();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception was thrown.");
            }
            finally
            {
                _hostApplicationLifetime.StopApplication();
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();

            await base.StopAsync(cancellationToken);

            _logger.LogInformation("Completed shutdown in {Milliseconds}ms.", sw.ElapsedMilliseconds);
        }
    }

    public static class LoggerExtensions
    {
        public static class EventIds
        {
            public static readonly EventId ExceptionCaught = new EventId(1000, "ExceptionCaught");
            public static readonly EventId OperationCancelledExceptionCaught = new EventId(1001, "OperationCancelledExceptionCaught");
        }

        public static void ExceptionOccurred(this ILogger logger, Exception ex) => logger.Log(LogLevel.Error, EventIds.ExceptionCaught, ex, "An exception occurred and was caught.");

        public static void OperationCancelledExceptionOccurred(this ILogger logger) => logger.Log(LogLevel.Information, EventIds.OperationCancelledExceptionCaught, "A task/operation cancelled exception was caught.");
    }
}
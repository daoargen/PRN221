using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service.OtherService;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

public class BackgroundWorkerService : BackgroundService
{
    private readonly ILogger _logger;
    private readonly BackgroundTaskService _backgroundTaskService;

    public BackgroundWorkerService(
        ILoggerFactory loggerFactory,
        BackgroundTaskService backgroundTaskService)
    {
        _logger = loggerFactory.CreateLogger<BackgroundWorkerService>();
        _backgroundTaskService = backgroundTaskService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (stoppingToken.IsCancellationRequested)
        {
            _logger.LogWarning("BackgroundWorkerService received cancellation request immediately.");
        }

        _logger.LogInformation("BackgroundWorkerService starting."); // Log khi service bắt đầu

        await RunBackgroundTaskAsync(stoppingToken);
    }

    private async Task RunBackgroundTaskAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            try
            {
                _logger.LogInformation("Updating room status..."); // Log trước khi update
                await _backgroundTaskService.UpdateRoomStatusAsync();
                _logger.LogInformation("Room status updated."); // Log sau khi update thành công
                _logger.LogInformation("Updating booking detail..."); // Log trước khi update
                await _backgroundTaskService.DeleteExpiredBookingDetailsAsync();
                _logger.LogInformation("Room booking detail updated."); // Log sau khi update thành công
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating room status.");
            }

            await Task.Delay(10000, stoppingToken);
        }

        _logger.LogInformation("BackgroundWorkerService stopping."); // Log khi service dừng
    }
}
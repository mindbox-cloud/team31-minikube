using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace team31;

public class ReadinessHealthCheck : IHealthCheck
{
    private static int? _ostatok = null;
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        if (_ostatok is null)
        {
            var random = new Random();
            var result = random.Next(0, 3);
            _ostatok = result;
        }
        
        return DateTime.Now.Minute % 3 != _ostatok
            ? Task.FromResult(HealthCheckResult.Healthy("A healthy result."))
            : Task.FromResult(HealthCheckResult.Unhealthy("An unhealthy result."));
    }
}
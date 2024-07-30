using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace team31;

public class ReadinessHealthCheck : IHealthCheck
{
    private static int? _remainder = null;
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        if (_remainder is null)
        {
            var random = new Random();
            var result = random.Next(0, 3);
            _remainder = result;
        }
        
        return DateTime.Now.Minute % 3 != _remainder
            ? Task.FromResult(HealthCheckResult.Healthy("A healthy result."))
            : Task.FromResult(HealthCheckResult.Unhealthy("An unhealthy result."));
    }
}
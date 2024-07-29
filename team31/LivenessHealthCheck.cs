using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace team31;

public class LivenessHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(
            HealthCheckResult.Healthy("A healthy result."));
    }
}
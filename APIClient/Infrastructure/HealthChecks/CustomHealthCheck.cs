using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Infrastructure.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var random = new Random();
                int res = random.Next(0, 100);

                if (res % 2 == 0)
                {
                    throw new Exception("Random Error Caugth!");
                }

                return Task.FromResult(HealthCheckResult.Healthy("Custom OK!!"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(ex.Message));
            }
        }
    }
}

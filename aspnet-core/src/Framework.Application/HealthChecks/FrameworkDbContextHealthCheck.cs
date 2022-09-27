using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Framework.EntityFrameworkCore;

namespace Framework.HealthChecks
{
    public class FrameworkDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public FrameworkDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("FrameworkDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("FrameworkDbContext could not connect to database"));
        }
    }
}

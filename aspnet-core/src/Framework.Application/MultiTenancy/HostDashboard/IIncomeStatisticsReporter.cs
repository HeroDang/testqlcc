using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.MultiTenancy.HostDashboard.Dto;

namespace Framework.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}
using System;
using Redux;

namespace DotNetReduxExample.Features.CpuUsage
{
    public class UpdateCpuUsageAction : IAction
    {
        public double CpuUsage => CpuUsageHelper.GetCpuUsageForProcess().Result;
    }
}
using System;
using Redux;

namespace DotNetReduxExample.Features.CpuUsage
{
    public static class CpuUsageReducer
    {
        public static Status Execute(Status current, IAction action)
        {
            switch(action)
            {
                case UpdateCpuUsageAction updateCpuUsageAction:
                    current.CpuUsage = updateCpuUsageAction.CpuUsage;
                    return current;

                default:
                    return current;
            }
        }
    }
}
using System;

namespace DotNetReduxExample.Features.Time
{
    public class StatusObserver : IObserver<Status>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
            => throw error;

        public void OnNext(Status status)
        {         
            System.Console.WriteLine($"{status.Time}: {status.CpuUsage:0.00}%");
        }
    }
}

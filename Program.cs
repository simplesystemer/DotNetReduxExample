using System;
using Redux;

namespace DotNetReduxExample
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Diagnostics.Tracing;
    using System.Diagnostics;
    using DotNetReduxExample.Features.Time;
    using DotNetReduxExample.Features.CpuUsage;

    class Program
    {        
        
        static void Main(string[] args)
        {
            var statusStore = new Store<Status>(new CombinedReducer<Status>(TimeReducer.Execute, CpuUsageReducer.Execute).Execute, new Status());
            statusStore.Subscribe(new StatusObserver());

            Task.WaitAll(
                new Task []{
                    new RepeatedTask(() => statusStore.Dispatch(new UpdateTimeAction(DateTime.Now)), TimeSpan.FromMilliseconds(1000) ),
                    new RepeatedTask(() => statusStore.Dispatch(new UpdateCpuUsageAction()), TimeSpan.FromMilliseconds(100) ),
                    new CpuConsumerTask(10)
                }
                .Select(StartTask)
                .ToArray()
            );
        }

        private static Task StartTask(Task task)
        { 
            task.Start(); 
            return task;
        }
      
    }
}

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetReduxExample.Features.CpuUsage
{
    public class CpuConsumerTask : Task
    {
        public CpuConsumerTask(int percentage) : base(() => ConsumeCPU(percentage))
        {
        }

        // Credits: https://github.com/jackowild/CpuUsagePercentageDotNetCoreExample
        private static void ConsumeCPU(int percentage)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > percentage)
                {
                    Thread.Sleep(100 - percentage);
                    watch.Reset();
                    watch.Start();
                }
            }
        }

    }
}
using System;

namespace DotNetReduxExample
{
    using System.Threading;
    using System.Threading.Tasks;

    public class RepeatedTask : Task
    {
        public RepeatedTask(Action action, TimeSpan delay) : base(WrapAction(action, delay)) { }

        private static Action WrapAction(Action action, TimeSpan delay)
            => new Action(() => { while(true){ action(); Thread.Sleep(delay); } });
    }
}

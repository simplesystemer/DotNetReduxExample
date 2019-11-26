using System;
using Redux;

namespace DotNetReduxExample.Features.Time
{
    public class UpdateTimeAction : IAction
    {
        public UpdateTimeAction(DateTime now)
        {
            Now = now;
        }

        public DateTimeOffset Now { get; set; }
    }
}

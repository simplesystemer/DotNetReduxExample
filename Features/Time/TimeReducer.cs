using System;
using Redux;

namespace DotNetReduxExample.Features.Time
{
    public static class TimeReducer
    {
        public static Status Execute(Status current, IAction action)
        {
            switch(action)
            {
                case UpdateTimeAction updateTimeAction:
                    current.Time = updateTimeAction.Now;
                    return current;

                default:
                    return current;
            }
        }
    }
}